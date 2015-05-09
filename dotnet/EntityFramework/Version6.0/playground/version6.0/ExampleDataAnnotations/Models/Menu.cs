using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDataAnnotations.Models
{
    [Table("ProgramMenu")]
    class Menu
    {
        [NotMapped]
        private string _superName;

        [Key]
        [Column(Order=1)]
        public string MainMenu { get; set; }

        [Key]
        [Column(Order = 2)]
        public string SubMenu { get; set; }

        public string Name { get { return MainMenu + "/" + SubMenu; } }

        [NotMapped]
        public string SuperName { get { return _superName; } set { _superName = value; } }

        [Column("MenuPos")]
        public int Pos { get; set; }
    }
}
