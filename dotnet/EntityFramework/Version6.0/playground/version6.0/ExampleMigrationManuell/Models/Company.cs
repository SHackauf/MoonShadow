using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMigrationManuell.Models
{
    class Company
    {
        public Company()
        {
            Employees = new List<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
