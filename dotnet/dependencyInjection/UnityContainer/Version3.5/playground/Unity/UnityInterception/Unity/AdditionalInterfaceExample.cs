using System;
using System.Collections.Generic;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

using UnityInterception.Bi;
using UnityInterception.Interception;

namespace UnityInterception.Unity
{
    class AdditionalInterfaceExample
    {
        public static void Run()
        {
            Console.Clear();
            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IKundeBi, KundeBi>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptionBehavior>(),
                    new InterceptionBehavior<AddInterfaceBehavior>(),
                    new AdditionalInterface<ILog>());

                var kundenBi = container.Resolve<IKundeBi>();
                ((ILog)kundenBi).Debug(">>>>Bla<<<<");
                var kunde = kundenBi.Load(1);
            }

            Console.ReadLine();
        }
    }

    public interface ILog
    {
        void Debug(string message);
    }

    class AddInterfaceBehavior : IInterceptionBehavior, ILog
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            if (input.MethodBase.DeclaringType == typeof(ILog) && input.MethodBase.Name == "Debug")
            {
                this.Debug(input.Arguments["message"].ToString());
                return input.CreateMethodReturn(null);
            }

            return getNext()(input, getNext);
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute { get { return true; } }

        public void Debug(string message)
        {
            Console.WriteLine("ILog::Debug => " + message);
        }
    }
}
