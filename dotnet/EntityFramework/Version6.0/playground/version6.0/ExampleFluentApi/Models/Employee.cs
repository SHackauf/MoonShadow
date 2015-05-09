using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleFluentApi.Models
{
    class Employee
    {
        public string PersonnelNumber { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
