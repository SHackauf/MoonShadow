using System;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.PolicyInjection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

using PolicyInjection.Bi;
using PolicyInjection.Bi.Admin;
using PolicyInjection.Interception;

namespace PolicyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
//            PolicyExample();
//            AttributExampe();
//            EnterpriseLibraryExample();
            EnterpriseLibraryExample2();
        }

        public static void PolicyExample()
        {
            Console.Clear();
            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IKundeBi, KundeBi>(
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<InterfaceInterceptor>());
                container.RegisterType<IProduktBi, ProduktBi>(
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<InterfaceInterceptor>());
                container.RegisterType<IConfigBi, ConfigBi>(
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<InterfaceInterceptor>());

                container.Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
                    .AddPolicy("log")
                    .AddMatchingRule<AssemblyMatchingRule>(
                        new InjectionConstructor(
                            new InjectionParameter("PolicyInjection")))
                    .AddCallHandler<LogHandler>(
                        new ContainerControlledLifetimeManager(),
                        new InjectionConstructor(),
                        new InjectionProperty("Order", 1));

                container.Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
                    .AddPolicy("test")
                    .AddMatchingRule<MemberNameMatchingRule>(
                        new InjectionConstructor(new[] { "Load*" }, true))
                    .AddMatchingRule<NamespaceMatchingRule>(
                        new InjectionConstructor("PolicyInjection.Bi", true))
                    .AddCallHandler<TestHandler>(
                        new ContainerControlledLifetimeManager(),
                        new InjectionConstructor(),
                        new InjectionProperty("Order", 2));

                var kundeBi = container.Resolve<IKundeBi>();
                kundeBi.LoadKunde(1);
                kundeBi.SaveKunde(1);

                var productBi = container.Resolve<IProduktBi>();
                productBi.LoadProdukt("P1");
                productBi.SaveProdukt("P1");

                var configBi = container.Resolve<IConfigBi>();
                configBi.LoadConfig();
                configBi.SaveConfig();

                Console.ReadLine();
            }
        }

        public static void AttributExampe()
        {
            Console.Clear();

            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IAttributBi, AttributBi>(
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<InterfaceInterceptor>());

                var attributBi = container.Resolve<IAttributBi>();
                attributBi.LoadConfig();
                attributBi.SaveConfig();

                Console.ReadLine();
            }
        }

        public static void EnterpriseLibraryExample()
        {
            Console.Clear();
            using (var container = new UnityContainer())
            {
                var configurationSource = ConfigurationSourceFactory.Create();
                var logWriterFactory = new LogWriterFactory(configurationSource);
                Logger.SetLogWriter(logWriterFactory.Create());

                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<IKundeBi, KundeBi>(
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<InterfaceInterceptor>());

                container.Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>()
                    .AddPolicy("log")
                    .AddMatchingRule<AssemblyMatchingRule>(
                        new InjectionConstructor(
                            new InjectionParameter("PolicyInjection")))
                    .AddCallHandler<LogCallHandler>(
                        new ContainerControlledLifetimeManager(),
                        new InjectionConstructor(9001, true, true, "start", "finish", true, false, true, 10, 1));

                var kundeBi = container.Resolve<IKundeBi>();
                kundeBi.LoadKunde(1);
                kundeBi.SaveKunde(1);

                Console.ReadLine();
            }
        }

        public static void EnterpriseLibraryExample2()
        {
            Console.Clear();
            using (var container = new UnityContainer())
            {
                var configurationSource = ConfigurationSourceFactory.Create();
                var logWriterFactory = new LogWriterFactory(configurationSource);
                Logger.SetLogWriter(logWriterFactory.Create());

                container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
                container.RegisterType<ILogCallHandlerAttributBi, LogCallHandlerAttributBi>(
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<InterfaceInterceptor>());

                var attributBi = container.Resolve<ILogCallHandlerAttributBi>();
                attributBi.LoadConfig();
                attributBi.SaveConfig();

                Console.ReadLine();
            }
        }
    }
}
