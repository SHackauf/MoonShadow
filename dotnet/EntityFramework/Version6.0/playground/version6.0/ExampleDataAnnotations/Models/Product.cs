using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDataAnnotations.Models
{
    class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? MainRangeId { get; set; }
        public int? SubRangeId { get; set; }

        [ForeignKey("MainRangeId")]
        public ProductRange MainRange { get; set; }

        [ForeignKey("SubRangeId")]
        public ProductRange SubRange { get; set; }
    }
}
