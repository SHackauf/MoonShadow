using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleLogger.Models;

using log4net;

namespace ExampleLogger.Services
{
    class MyDbContext : DbContext
    {
        private static readonly ILog _log = LogManager.GetLogger("EntityFramework");

        public MyDbContext() : base("EF.Logger")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
            Database.Log = s => _log.Debug(s);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
