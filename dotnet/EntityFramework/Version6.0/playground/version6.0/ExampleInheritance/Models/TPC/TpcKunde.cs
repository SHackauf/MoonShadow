﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleInheritance.Models.TPC
{
    class TpcKunde : TpcPerson
    {
        public string Company { get; set; }
    }
}
