using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleAsync.Models;
using ExampleAsync.Services;

namespace ExampleAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            using (var context = new MyDbContext())
            {
                context.Database.Initialize(false);
            }

            TestSave();
            TestLoad();
            Console.WriteLine("End (please press key)");
            Console.Read();
        }

        private void TestSave()
        {
            Console.WriteLine("Start test save...");

            var watchSingelMethod = Stopwatch.StartNew();
            var companies = new List<Company>();
            for (int pos = 0; pos < 500; pos++)
            {
                companies.Add(new Company { Name = "Green AG " + pos } );
            }
            var tasks = companies.Select(SaveCompany).ToList();
            Task.WhenAll(tasks);
            watchSingelMethod.Stop();

            var watchSync = Stopwatch.StartNew();
            using (var context = new MyDbContext())
            {
                for (int pos = 0; pos < 500; pos++)
                {
                    context.Companies.Add(new Company { Name = "Red GmbH " + pos });
                }
                context.SaveChanges();
                watchSync.Stop();
            }

            var watchAsync = Stopwatch.StartNew();
            using (var context = new MyDbContext())
            {
                for (int pos = 0; pos < 500; pos++)
                {
                    context.Companies.Add(new Company { Name = "Blue KG" + pos });
                }
                context.SaveChangesAsync().Wait();
                watchAsync.Stop();
            }

            Console.WriteLine("   Time async single: " + watchSingelMethod.ElapsedMilliseconds);
            Console.WriteLine("   Time sync:         " + watchSync.ElapsedMilliseconds);
            Console.WriteLine("   Time async:        " + watchAsync.ElapsedMilliseconds);

            Console.WriteLine("End test save...");
        }

        private void TestLoad()
        {
            Console.WriteLine("Start test load...");

            var watchSync = Stopwatch.StartNew();
            using (var context = new MyDbContext())
            {
                Console.WriteLine("Start sync LoadCustomer...");
                var customersSync = from company in context.Companies select company;
                Console.WriteLine("   Sync found " + customersSync.Count() + " companies");
            }
            watchSync.Stop();

            var watchAsync = Stopwatch.StartNew();
            var companies = LoadCompanies();
            companies.Wait();

            Console.WriteLine("   Async found " + companies.Result.Count + " companies");

            watchAsync.Stop();

            Console.WriteLine("   Time sync:         " + watchSync.ElapsedMilliseconds);
            Console.WriteLine("   Time async:        " + watchAsync.ElapsedMilliseconds);

            Console.WriteLine("End test load...");
        }

        private async Task<List<Company>> LoadCompanies()
        {
            Console.WriteLine("LoadCompanies <<");

            List<Company> result;
            using (var context = new MyDbContext())
            {
                Console.WriteLine("Start LoadCompanies...");
                result = await (from company in context.Companies select company).ToListAsync();
            }

            Console.WriteLine("LoadCompanies >>");
            return result;
        }

        private static async Task SaveCompany(Company company)
        {
            Console.WriteLine("SaveCompany <<");

            using (var context = new MyDbContext())
            {
                context.Companies.Add(company);
                await (context.SaveChangesAsync());
            }

            Console.WriteLine("SaveCompany >>");
        }

        private static async Task<List<Employee>> LoadEmployees()
        {
            Console.WriteLine("LoadEmployees <<");

            List<Employee> result;
            using (var context = new MyDbContext())
            {
                Console.WriteLine("Start LoadCompanies...");
                result = await (from employee in context.Employees select employee).ToListAsync();
            }

            Console.WriteLine("LoadEmployees >>");
            return result;
        }

        private static async Task SaveEmployee(Employee employee)
        {
            Console.WriteLine("SaveEmployee <<");

            using (var context = new MyDbContext())
            {
                context.Employees.Add(employee);
                await (context.SaveChangesAsync());
            }

            Console.WriteLine("End SaveCompany...");
            Console.WriteLine("SaveEmployee >>");
        }

    }
}
