using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleTransaction.Models;

namespace ExampleTransaction.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("EF.Transaction")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
