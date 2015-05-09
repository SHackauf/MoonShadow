using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInheritance.Models.TPT
{
    [Table("TptMitarbeiters")]
    class TptMitarbeiter : TptPerson
    {
        public string PersonnelNumber { get; set; }
    }
}
