using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DescriptionAttributeEnum.Null.GetDescription());
            Console.WriteLine(DescriptionAttributeEnum.One.GetDescription());
            Console.WriteLine(DescriptionAttributeEnum.Two.GetDescription());
            Console.WriteLine("-----");
            Console.WriteLine(OwnAttributeEnum.Null.GetDescription() + " / " + OwnAttributeEnum.Null.GetDbValue());
            Console.WriteLine(OwnAttributeEnum.One.GetDescription() + " / " + OwnAttributeEnum.One.GetDbValue());
            Console.WriteLine(OwnAttributeEnum.Two.GetDescription() + " / " + OwnAttributeEnum.Two.GetDbValue());
            Console.ReadLine();
        }
    }
}
