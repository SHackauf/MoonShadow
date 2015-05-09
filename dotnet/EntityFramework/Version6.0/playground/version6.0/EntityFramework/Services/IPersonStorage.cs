using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.Models;

namespace EntityFramework.Services
{
    interface IPersonStorage
    {
        IEnumerable<IPerson> FindAll();
    }
}
