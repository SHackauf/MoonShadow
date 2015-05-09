using System;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace PolicyInjection.Interception
{
    public class LogHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.Write("<<<Log>>> {0}:: {1} => ", input.Target, input.MethodBase);
            foreach (var argument in input.Arguments)
            {
                Console.Write("[{0}]", argument);
            }
            Console.WriteLine();
            
            var result = getNext()(input, getNext);
//            if (result.Exception != null)
//            {
//                Console.WriteLine("<<<Log>>>    << Exception: {0}", result.Exception.Message);
//            }
//            else
//            {
//                Console.Write("<<<Log>>>    << Return: [{0}]", result.ReturnValue);
//            
//                foreach (var output in result.Outputs)
//                {
//            
//                    Console.Write("[out {0} [{1}]]", output.GetType().Name, output);
//                }
//            }
//            Console.WriteLine();
            
            return result;
        }

        public int Order { get; set; }
    }
}
