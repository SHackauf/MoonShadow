using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleConfiguration.Models;

namespace ExampleConfiguration.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("EF.Configuration")
        {
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseAlways<MyDbContext>());
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
