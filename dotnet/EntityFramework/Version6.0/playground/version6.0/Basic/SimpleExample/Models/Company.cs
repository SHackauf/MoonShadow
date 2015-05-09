using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWpfCore.Models;

namespace SimpleExample.Models
{
    class Company //: ModelBase // ICompany
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<IPerson> Employee { get; set; }
    }
}
