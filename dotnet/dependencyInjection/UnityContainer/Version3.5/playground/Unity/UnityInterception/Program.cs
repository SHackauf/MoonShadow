

using System;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

using UnityInterception.Bi;
using UnityInterception.Interception;

namespace UnityInterception
{
    class Program
    {
        static void Main(string[] args)
        {
            //InterfaceInterceptorExample();
            //TransparentProxyInterceptorExample();
            //VirtualMethodInterceptorExample();
            //AdditionalInterfaceExample();
            InterceptionWithoutContainerExample();
        }

        public static void InterfaceInterceptorExample()
        {
            Console.Clear();
            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IKundeBi, KundeBi>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptionBehavior>(),
                    new InterceptionBehavior<Logging2InterceptionBehavior>());

                var kundenBi = container.Resolve<IKundeBi>();
                var kunde = kundenBi.Load(1);
                string detail;
                kundenBi.Check(kunde, out detail);
                kundenBi.Save(kunde);
            }

            Console.ReadLine();
        }

        public static void TransparentProxyInterceptorExample()
        {
            Console.Clear();
            Console.WriteLine("=== with InterfaceInterceptor ===");
            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IKundeBi, KundeBi>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptionBehavior>());

                var kundenBi = container.Resolve<IKundeBi>();
                kundenBi.ToString();
            }

            Console.WriteLine("=== with TransparentProxyInterceptor ===");

            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IKundeBi, KundeBi>(
                    new Interceptor<TransparentProxyInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptionBehavior>());

                var kundenBi = container.Resolve<IKundeBi>();
                kundenBi.ToString();
            }

            Console.ReadLine();
        }

        public static void VirtualMethodInterceptorExample()
        {
            Console.Clear();
            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IKundeBi, KundeBi>(
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptionBehavior>());

                var kundenBi = container.Resolve<IKundeBi>();
                var kunde = kundenBi.Load(1);
                kundenBi.Delete(kunde);
            }

            Console.ReadLine();
        }

        public static void AdditionalInterfaceExample()
        {
            UnityInterception.Unity.AdditionalInterfaceExample.Run();
        }

        public static void InterceptionWithoutContainerExample()
        {
            Console.Clear();
            var kundeBi = Intercept.ThroughProxy<IKundeBi>(
                new KundeBi(), 
                new InterfaceInterceptor(), 
                new IInterceptionBehavior[]
                    {
                        new LoggingInterceptionBehavior()
                    });
            var kunde = kundeBi.Load(1);

            kundeBi = new KundeBi();
            kundeBi.Load(2);

            kundeBi = Intercept.ThroughProxy<IKundeBi>(
                kundeBi,
                new InterfaceInterceptor(),
                new IInterceptionBehavior[]
                    {
                        new LoggingInterceptionBehavior()
                    });
            kundeBi.Load(3);

            Console.ReadLine();
        }
    }
}
