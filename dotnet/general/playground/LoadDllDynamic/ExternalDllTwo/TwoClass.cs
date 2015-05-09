using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interfaces;

namespace ExternalDllTwo
{
    public sealed class TwoClass : IExternal
    {
        public void DoSomething(string aText)
        {
            Console.WriteLine("Two - " + aText);
        }

        public string ReadSomething()
        {
            return "I am two.";
        }
    }
}
