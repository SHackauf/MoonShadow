using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRelationship.Models.ManyToMany
{
    class User2
    {
        public User2()
        {
            Applications = new List<Application2>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application2> Applications { get; set; } 
    }
}
