using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleRelationship.Services;

namespace ExampleRelationship
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
