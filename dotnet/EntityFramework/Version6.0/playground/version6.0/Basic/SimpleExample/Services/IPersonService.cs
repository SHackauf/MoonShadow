using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleExample.Models;

namespace SimpleExample.Services
{
    interface IPersonService : IDisposable
    {
        List<Person> FindAll();

        Person Save(Person person);
    }
}
