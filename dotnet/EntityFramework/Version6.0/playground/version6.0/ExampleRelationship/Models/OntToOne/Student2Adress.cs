using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRelationship.Models.OntToOne
{
    class Student2Adress
    {
        public int StudentId { get; set; }

        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual Student2 Student2 { get; set; }
    }
}
