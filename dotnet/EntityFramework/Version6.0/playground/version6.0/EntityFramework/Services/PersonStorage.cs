using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.Models;

namespace EntityFramework.Services
{
    public sealed class PersonStorage : IPersonStorage
    {
        private IEnumerable<IPerson> _storage = new List<IPerson>
            {
                new Person{Id = 0, Firstname = "Donald", Lastname = "Duck", Street = "Duck Road 1", Zip = "50000", City = "Entenhausen", Country = "Germany"},
                new Person{Id = 1, Firstname = "Dagobert", Lastname = "Duck", Street = "Duck Road 2", Zip = "50000", City = "Entenhausen", Country = "Germany"},
                new Person{Id = 2, Firstname = "Mikey", Lastname = "Maus", Street = "Maus Street 1", Zip = "50000", City = "Entenhausen", Country = "Germany"}
            };


        public IEnumerable<IPerson> FindAll()
        {
            return _storage;
        }
    }
}
