using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pozdravlyator.Application.Repositories;
using Pozdravlyator.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlyator.Infrastructure
{
    public static class DataAccessModule
    {
        public sealed class ModuleConfiguration
        {
            public IServiceCollection Services { get; init; }
        }

        public static IServiceCollection AddDataAccessModule(
            this IServiceCollection services,
            Action<ModuleConfiguration> action
        )
        {
            var moduleConfiguration = new ModuleConfiguration
            {
                Services = services
            };
            action(moduleConfiguration);
            return services;
        }

        public static void InSqlite(this ModuleConfiguration moduleConfiguration, string connectionString)
        {
            moduleConfiguration.Services.AddDbContextPool<DatabaseContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlite(connectionString, builder =>
                    builder.MigrationsAssembly(
                //typeof( DataAccessModule).Assembly.FullName)
                typeof(DatabaseContextModelSnapshot).Assembly.FullName)
                );
            });

            moduleConfiguration.Services.AddScoped(typeof(IRepository<,>), typeof(IBirthdayRepository));
        }
    }
}
