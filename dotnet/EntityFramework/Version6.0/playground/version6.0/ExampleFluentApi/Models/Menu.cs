using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleFluentApi.Models
{
    class Menu
    {
        private string _superName;

        public string MainMenu { get; set; }

        public string SubMenu { get; set; }

        public string Name { get { return MainMenu + "/" + SubMenu; } }

        public string SuperName { get { return _superName; } set { _superName = value; } }

        public int Pos { get; set; }
    }
}
