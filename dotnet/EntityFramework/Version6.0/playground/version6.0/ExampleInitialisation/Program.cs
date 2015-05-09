using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleInitialisation.Models;
using ExampleInitialisation.Services;

namespace ExampleInitialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
//                context.Companies.Add(new Company { Id = 1, Name = "Green AG" });
//                context.Companies.Add(new Company { Id = 2, Name = "Red GmbH" });
//                context.SaveChanges();

                var companies = context.Companies.ToList();
                foreach (var company in companies)
                {
                    Console.WriteLine(company.Name);
                }
            }
        }
    }
}
