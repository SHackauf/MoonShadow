using System;
using System.Collections.Generic;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace UnityInterception.Interception
{
    class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Logging => 1");

            Console.Write("   >> {0}:: {1} => ", input.Target, input.MethodBase);
            foreach (var argument in input.Arguments)
            {
                Console.Write("[{0}]", argument);
            }
            Console.WriteLine();

            var result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                Console.WriteLine("   << Exception: {0}", result.Exception.Message);
            }
            else
            {
                Console.Write("   << Return: [{0}]", result.ReturnValue);

                foreach (var output in result.Outputs)
                {
                    
                    Console.Write("[out {0} [{1}]]", output.GetType().Name, output);
                }
            }
            Console.WriteLine();

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute { get { return true; } }
    }
}
