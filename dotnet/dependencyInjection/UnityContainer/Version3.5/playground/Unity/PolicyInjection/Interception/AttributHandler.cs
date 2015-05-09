using System;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace PolicyInjection.Interception
{
    public class AttributHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("<<<Attribute>>> {0}:: {1}", input.Target, input.MethodBase);
            return getNext()(input, getNext);
        }

        public int Order { get; set; }
    }

    public class AttributeHandlerAttribute : HandlerAttribute
    {
        private readonly int _order;
        public AttributeHandlerAttribute(int order)
        {
            this._order = order;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new AttributHandler() { Order = _order };
        }
    }
}
