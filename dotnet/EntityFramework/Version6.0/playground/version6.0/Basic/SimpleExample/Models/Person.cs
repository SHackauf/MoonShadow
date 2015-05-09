using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWpfCore.Models;

namespace SimpleExample.Models
{
    class Person //: ModelBase//, IPerson
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Foreign key for Company
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
