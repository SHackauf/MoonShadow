using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleExample.Models;

namespace SimpleExample.Services
{
    class PersonService : IPersonService
    {
        private readonly MyDbContext _dbContext;

        public PersonService()
        {
            _dbContext = new MyDbContext();
        }

        public List<Person> FindAll()
        {
            return _dbContext.Persons.ToList();
        }

        public Person Save(Person person)
        {
            if (person.Id == null)
            {
                var maxId = _dbContext.Persons.Max(p => p.Id);
                person.Id = maxId != null ? maxId + 1 : 0;
            }
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            return person;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
