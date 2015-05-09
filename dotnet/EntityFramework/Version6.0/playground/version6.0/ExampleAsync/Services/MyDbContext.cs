using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleAsync.Models;

namespace ExampleAsync.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("EF.Async")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
