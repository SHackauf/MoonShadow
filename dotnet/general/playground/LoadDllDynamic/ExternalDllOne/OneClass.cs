using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interfaces;

namespace ExternalDllOne
{
    public sealed class OneClass : IExternal
    {
        public void DoSomething(string aText)
        {
            Console.WriteLine("One - " + aText);
        }

        public string ReadSomething()
        {
            return "I am one.";
        }
    }
}
