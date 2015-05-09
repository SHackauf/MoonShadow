using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleFluentApi.Models
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? MainRangeId { get; set; }
        public int? SubRangeId { get; set; }

        public ProductRange MainRange { get; set; }
        public ProductRange SubRange { get; set; }
    }
}
