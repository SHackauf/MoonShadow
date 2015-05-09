using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInheritance.Models.TPT
{
    [Table("TptKunden")]
    class TptKunde : TptPerson
    {
        public string Company { get; set; }
    }
}
