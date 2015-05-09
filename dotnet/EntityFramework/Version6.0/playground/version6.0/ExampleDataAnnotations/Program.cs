using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleDataAnnotations.Models;
using ExampleDataAnnotations.Services;

namespace ExampleDataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                //context.Database.Create();

                context.Database.ExecuteSqlCommand("TRUNCATE TABLE Employees");
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE ProgramMenu");

                context.Employees.Add(new Employee { PersonnelNumber = "4711", Firstname = "Donald", Lastname = "Duck" });
                context.Employees.Add(new Employee { PersonnelNumber = "4712", Firstname = "Dagobert", Lastname = "Duck" });
                context.SaveChanges();

                var employees = context.Employees.ToList();
                var employee = employees[0];
                employee.Firstname = employee.Firstname + "2";
                
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
//                    foreach (var entry in ex.Entries)
//                    {
//                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
//                    }

                    var objContext = ((IObjectContextAdapter)context).ObjectContext;
                    objContext.Refresh(RefreshMode.ClientWins, ex.Entries.Select(e => e.Entity));
                    objContext.SaveChanges();
                }

                var menus = context.Menus.ToList();
                var customers = context.Customers.ToList();
            }
        }
    }
}
