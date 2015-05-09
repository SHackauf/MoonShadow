using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRelationship.Models.OntToOne
{
    class Student1Adress
    {
        [Key, ForeignKey("Student1")]
        public int StudentId { get; set; }

        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual Student1 Student1 { get; set; }
    }
}
