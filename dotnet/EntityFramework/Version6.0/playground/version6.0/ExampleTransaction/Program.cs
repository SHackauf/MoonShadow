using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleTransaction.Models;
using ExampleTransaction.Services;

namespace ExampleTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                context.Database.Initialize(false);

                // Testdata before using transaction
                context.Companies.Add(new Company() { Name= "Green AG" });
                context.SaveChanges();

                using (DbContextTransaction dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var company = new Company { Name = "Red GmbH" };
                        context.Companies.Add(company);

                        context.Employees.Add(new Employee { Firstname = "Donald", Lastname = "Duck", Company = company } );
                        context.Employees.Add(new Employee { Firstname = "Dagobert", Lastname = "Duck", Company = company });

                        //saves all above operations within one transaction
                        context.SaveChanges();

                        //commit transaction
                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                    }
                }
            }
        }
    }
}
