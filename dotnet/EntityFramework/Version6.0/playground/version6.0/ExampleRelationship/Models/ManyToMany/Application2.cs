using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRelationship.Models.ManyToMany
{
    class Application2
    {
        public Application2()
        {
            Users = new List<User2>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User2> Users { get; set; } 
    }
}
