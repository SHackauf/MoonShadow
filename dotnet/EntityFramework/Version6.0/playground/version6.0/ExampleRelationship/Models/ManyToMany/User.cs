using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRelationship.Models.ManyToMany
{
    class User
    {
        public User()
        {
            Applications = new List<Application>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application> Applications { get; set; } 
    }
}
