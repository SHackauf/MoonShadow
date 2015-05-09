using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleInitialisation.Models;

namespace ExampleInitialisation.Services
{
    class MyDbContext : DbContext 
    {
        public MyDbContext() : base("EF.Initialisation")
        {
            //Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());
            //Database.SetInitializer<MyDbContext>(new DropCreateDatabaseIfModelChanges<MyDbContext>());
            //Database.SetInitializer<MyDbContext>(new DropCreateDatabaseAlways<MyDbContext>());
            //Database.SetInitializer<MyDbContext>(new MyDbInitializer<MyDbContext>());
            Database.SetInitializer<MyDbContext>(new TestdataDbInitializer());

            //Disable initializer
            //Database.SetInitializer<MyDbContext>(null);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    class MyDbInitializer<TContext> : DropCreateDatabaseIfModelChanges<TContext> where TContext : DbContext
    {
        protected override void Seed(TContext context)
        {
            base.Seed(context);
        }
    }

    class TestdataDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            var company1 = new Company() { Name = "Green AG"};

            var company2 = new Company() { Name = "Red GmbH" };
            var employee21 = new Employee { Firstname = "Donald", Lastname = "Duck", Company = company2 };
            var employee22 = new Employee { Firstname = "Dagobert", Lastname = "Duck", Company = company2 };
            

            context.Companies.Add(company1);
            context.Companies.Add(company2);
            context.Employees.Add(employee21);
            context.Employees.Add(employee22);

            base.Seed(context);
        }
    }
}
