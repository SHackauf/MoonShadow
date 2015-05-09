using System.Collections.Generic;

namespace ExampleTransaction.Models
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
    }
}
