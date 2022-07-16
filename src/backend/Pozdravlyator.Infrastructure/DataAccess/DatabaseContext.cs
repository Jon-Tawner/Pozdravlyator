using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pozdravlyator.Domain;

namespace Pozdravlyator.Infrastructure.DataAccess
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {}

        public DbSet<Birthday> Birthdays { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;

    }

    //public class SampleContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    //{
    //    public DatabaseContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

    //        ConfigurationBuilder builder = new ConfigurationBuilder();
    //        IConfigurationRoot config = builder.Build();

    //        string connectionString = config.GetConnectionString("DefaultConnection");
    //        optionsBuilder.UseSqlite(connectionString);
    //        return new DatabaseContext(optionsBuilder.Options);
    //    }
    //}
}