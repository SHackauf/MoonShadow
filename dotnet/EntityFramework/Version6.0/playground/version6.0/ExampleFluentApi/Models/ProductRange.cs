using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleFluentApi.Models
{
    class ProductRange
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> MainProducts { get; set; }
        public ICollection<Product> SubProducts { get; set; }
    }
}
