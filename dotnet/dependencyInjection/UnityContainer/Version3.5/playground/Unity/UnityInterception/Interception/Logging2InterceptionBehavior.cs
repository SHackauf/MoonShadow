using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace UnityInterception.Interception
{
    class Logging2InterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Logging => 2");
            return getNext()(input, getNext);
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute { get { return true; } }
    }
}
