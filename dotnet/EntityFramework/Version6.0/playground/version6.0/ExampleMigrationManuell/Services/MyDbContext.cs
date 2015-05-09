using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleMigrationManuell.Models;

namespace ExampleMigrationManuell.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("EF.MigrationManuell")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
