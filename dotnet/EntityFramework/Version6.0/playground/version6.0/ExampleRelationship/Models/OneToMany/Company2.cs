using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRelationship.Models.OneToMany
{
    class Company2
    {
        public Company2()
        {
            Employees = new List<Employee2>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee2> Employees { get; set; }
    }
}
