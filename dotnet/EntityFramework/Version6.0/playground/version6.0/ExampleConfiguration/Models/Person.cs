using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConfiguration.Models
{
    class Person
    {
        public string PersonnelNumber { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
