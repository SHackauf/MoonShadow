using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleMigrationAuto.Services;

namespace ExampleMigrationAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var companies = context.Companies.ToList();
                foreach (var company in companies)
                {
                    Console.WriteLine(company.Name);
                }

                var employees = context.Employees.ToList();
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.Lastname + ", " + employee.Firstname);
                }
            }
        }
    }
}
