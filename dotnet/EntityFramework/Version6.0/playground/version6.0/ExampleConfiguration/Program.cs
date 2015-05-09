using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleConfiguration.Services;

namespace ExampleConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
