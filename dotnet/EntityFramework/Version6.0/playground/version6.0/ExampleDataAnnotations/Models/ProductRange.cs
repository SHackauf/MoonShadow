using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDataAnnotations.Models
{
    class ProductRange
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("MainRange")]
        public ICollection<Product> MainProducts { get; set; }

        [InverseProperty("SubRange")]
        public ICollection<Product> SubProducts { get; set; }
    }
}
