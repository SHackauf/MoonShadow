using System;
using System.Collections.Generic;
using Interfaces;

namespace LoadDllDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblies = new List<string>
                {
                    "ExternalDllOne.OneClass,ExternalDllOne",
                    "ExternalDllTwo.TwoClass,ExternalDllTwo"
                };

            foreach (var assembly in assemblies)
            {
                try
                {
                    Console.WriteLine("Create: " + assembly);
                    var external = InstanceBuilder.CreateInstance(assembly) as IExternal;
                    if (external != null)
                    {
                        external.DoSomething("Do it");
                        Console.WriteLine("Read result: " + external.ReadSomething());
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Load " + assembly + ": " + exception.Message);
                    if (exception.InnerException != null)
                    {
                        Console.WriteLine("Load " + assembly + ": " + exception.InnerException.Message);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
