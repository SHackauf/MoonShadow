using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleLogger.Services;

using log4net;

namespace ExampleLogger
{
    // http://msdn.microsoft.com/de-de/magazine/gg490349.aspx
    // http://blog.oneunicorn.com/2013/05/08/ef6-sql-logging-part-1-simple-logging/
    // http://blog.oneunicorn.com/2013/05/09/ef6-sql-logging-part-2-changing-the-contentformatting/
    // http://blog.oneunicorn.com/2013/05/14/ef6-sql-logging-part-3-interception-building-blocks/
    // http://blog.oneunicorn.com/2014/02/09/ef-6-1-turning-on-logging-without-recompiling/
    // http://logging.apache.org/log4net/release/manual/configuration.html

    class Program
    {
        static Program()
        {
            if (LogManager.GetRepository().Configured == false)
            {
                log4net.Config.XmlConfigurator.Configure();
            }
        }

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
