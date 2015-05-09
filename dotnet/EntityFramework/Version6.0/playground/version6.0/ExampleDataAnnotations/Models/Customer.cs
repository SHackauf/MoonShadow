using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWpfCore.Models;

namespace ExampleDataAnnotations.Models
{
    class Customer : ModelBase
    {
        [NotMapped]
        private int _id;

        [NotMapped]
        private string _name;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        [Required]
        [MaxLength(50)]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
