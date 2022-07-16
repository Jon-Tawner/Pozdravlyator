using Microsoft.EntityFrameworkCore;
using Pozdravlyator.Application.Repositories;
using Pozdravlyator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlyator.Infrastructure.DataAccess.Repositories
{
    public class BirthdayRepository : IRepository<Birthday, int>
    {
        protected readonly DatabaseContext _DbContext;

        public BirthdayRepository(DatabaseContext context)
        {
            _DbContext = context;
        }

        public async Task<int> Count(CancellationToken cancellationToken)
        {
            var data = _DbContext.Set<Birthday>().AsNoTracking();
            return await data.CountAsync(cancellationToken);
        }

        public async Task Delete(Birthday entity, CancellationToken cancellationToken)
        {
            var entry = _DbContext.Entry(entity);
            if (entry.State !=EntityState.Detached)
            {
                _DbContext.Remove(entity);
            }

            await _DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Birthday> FindById(int id, CancellationToken cancellationToken)
        {
            return await _DbContext.FindAsync<Birthday>(keyValues: new object[] { id }, cancellationToken: cancellationToken);
        }

        public async Task<Birthday> FindWhere(Expression<Func<Birthday, bool>> predicate, CancellationToken cancellationToken)
        {
            var data = _DbContext.Set<Birthday>().AsNoTracking();

            return await data.Where(predicate).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Birthday>> GetPaged(int offset, int limit, CancellationToken cancellationToken)
        {
            var data = _DbContext.Set<Birthday>().AsNoTracking();

            return await data
                .OrderBy(e => e.Id)
                .Take(limit)
                .Skip(offset)
                .ToListAsync(cancellationToken);
        }

        public async Task Save(Birthday entity, CancellationToken cancellationToken)
        {
            var entry = _DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                await _DbContext.AddAsync(entity, cancellationToken);
            }

            await _DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
