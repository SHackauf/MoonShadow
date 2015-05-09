using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleDataAnnotations.Models;

namespace ExampleDataAnnotations.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("EF.DataAnnotations")
        {
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseAlways<MyDbContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRange> ProductRanges { get; set; }
    }
}
