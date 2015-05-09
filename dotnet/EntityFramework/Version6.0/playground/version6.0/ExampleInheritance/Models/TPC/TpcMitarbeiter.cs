using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInheritance.Models.TPC
{
    class TpcMitarbeiter : TpcPerson
    {
        public string PersonnelNumber { get; set; }
    }
}
