using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDatabinding.Model
{
    interface IPerson
    {
        int Id { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
    }
}
