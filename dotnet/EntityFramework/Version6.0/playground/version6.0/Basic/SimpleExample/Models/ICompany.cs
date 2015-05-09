using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWpfCore.Models;

namespace SimpleExample.Models
{
    interface ICompany : IModelBase
    {
        int? Id { get; set; }
        string Name { get; set; }
        ICollection<IPerson> Employee { get; set; }
    }
}
