using System;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace PolicyInjection.Interception
{
    public class TestHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("<<<Test>>> {0}:: {1}", input.Target, input.MethodBase);
            return getNext()(input, getNext);
        }

        public int Order { get; set; }
    }
}
