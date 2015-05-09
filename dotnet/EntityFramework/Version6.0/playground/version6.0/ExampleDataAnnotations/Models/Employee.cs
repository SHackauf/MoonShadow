using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDataAnnotations.Models
{
    class Employee
    {
        [Key]
        public string PersonnelNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Lastname { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
