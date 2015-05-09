using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleInheritance.Models.TPC;
using ExampleInheritance.Models.TPH;
using ExampleInheritance.Models.TPT;
using ExampleInheritance.Services;

namespace ExampleInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                TestModeTph(context);
                TestModeTpt(context);
                TestModeTpc(context);
            }
        }

        // Table per Hierarchy (TPH)
        private static void TestModeTph(MyDbContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE TphPersons");
            context.TphPerson.Add(new TphKunde { Id = 1, Firstname = "Donald", Lastname = "Duck", Company = "Test AG", Type = "Kd" });
            context.TphPerson.Add(new TphMitarbeiter { Id = 2, Firstname = "Dagobert", Lastname = "Duck", PersonnelNumber = "4711", Type = "Mit" });
            context.SaveChanges();
            var resultAll = context.TphPerson.ToList();

            var resultKunden = context.TphPerson.OfType<TphKunde>().ToList();
            var resultMitarbeiter = context.TphPerson.OfType<TphMitarbeiter>().ToList();
        }

        // Table per Type (TPT)
        private static void TestModeTpt(MyDbContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE TptMitarbeiters");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE TptKunden");
            context.TptPerson.Add(new TptKunde { Id = 1, Firstname = "Donald", Lastname = "Duck", Company = "Test AG" });
            context.TptPerson.Add(new TptMitarbeiter { Id = 2, Firstname = "Dagobert", Lastname = "Duck", PersonnelNumber = "4711" });
            context.SaveChanges();
            var resultAll = context.TptPerson.ToList();

            var resultKunden = context.TptPerson.OfType<TptKunde>().ToList();
            var resultMitarbeiter = context.TptPerson.OfType<TptMitarbeiter>().ToList();
            var resultSpecialMitarbeiter = context.TptPerson.Find(2);
        }

        // Table per Concrete Type (TPC)
        private static void TestModeTpc(MyDbContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE TpcMitarbeiter");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE TpcKunden");
            context.TpcPerson.Add(new TpcKunde { Id = 1, Firstname = "Donald", Lastname = "Duck", Company = "Test AG" });
            context.TpcPerson.Add(new TpcMitarbeiter { Id = 2, Firstname = "Dagobert", Lastname = "Duck", PersonnelNumber = "4711" });
            context.SaveChanges();
            var resultAll = context.TpcPerson.ToList();

            var resultKunden = context.TpcPerson.OfType<TpcKunde>().ToList();
            var resultMitarbeiter = context.TpcPerson.OfType<TpcMitarbeiter>().ToList();
            var resultSpecialMitarbeiter = context.TpcPerson.Find(2);
        }
    }
}
