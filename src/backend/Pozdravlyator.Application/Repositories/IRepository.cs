using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Pozdravlyator.Application.Repositories
{
    public interface IRepository<TEntity, in TId>
    {
        Task<TEntity> FindById(TId id, CancellationToken cancellationToken);
        Task Save(TEntity entity, CancellationToken cancellationToken);

        Task Delete(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<int> Count(CancellationToken cancellationToken);
        
        Task<IEnumerable<TEntity>> GetPaged(int offset, int limit, CancellationToken cancellationToken);
    }
}
