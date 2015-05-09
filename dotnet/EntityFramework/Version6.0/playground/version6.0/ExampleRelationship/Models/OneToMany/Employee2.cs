using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRelationship.Models.OneToMany
{
    class Employee2
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company2 Company { get; set; }
    }
}
