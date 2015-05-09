using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleExample.Models;

namespace SimpleExample.Services
{
    class MyDbContext : DbContext
    {
        //public MyDbContext() : base() { }
        public MyDbContext() : base("EF.SimpleExample") { }
        //public MyDbContext() : base("name=MyDBConnectionString") { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
