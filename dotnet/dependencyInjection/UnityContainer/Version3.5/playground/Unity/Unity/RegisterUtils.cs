using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using Unity.Bi;

namespace Unity
{
    internal class RegisterUtils
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDatabase, MyDatabase>();
            container.RegisterType<IDatabase, Database>("Database");
            container.RegisterType<IDatabase, HisDatabase>("HisDatabase", new InjectionProperty("Name", "HisName"));
            
//            var db = container.Resolve<IDatabase>();
//            var dao = container.Resolve<KundeDao>();

//            container.RegisterType<IDatabase, YourDatabase>(new InjectionConstructor("YourDb", "YourTable"));
//            var dao = container.Resolve<KundeDao>();

//            var account = ApplicationConfiguration.GetStorageAccount("DataConnectionString");
//            container.RegisterInstance(account);

            container.RegisterType(typeof(IList<>), typeof(List<>), new InjectionConstructor());
//            var list = container.Resolve<IList<string>>();

//            container.RegisterType(typeof(IList<>), typeof(List<>), new InjectionConstructor(typeof(int)));
//            var list = container.Resolve<IList<string>>(new ParameterOverride("capacity", 5));

//            var container = new UnityContainer();
//            container.RegisterType(typeof(IList<>), typeof(List<>), "standard", new InjectionConstructor());
//            container.RegisterType(typeof(IList<>), typeof(List<>), "capacity", new InjectionConstructor(5));
//            var list1 = container.Resolve<IList<string>>("standard");
//            var list2 = container.Resolve<IList<string>>("capacity");

            container.RegisterType<IDatabase, YourDatabase>(new InjectionConstructor("YourDb", "YourTable"));
            var childContainer = container.CreateChildContainer();
            childContainer.RegisterType<IDatabase, YourDatabase>(new InjectionConstructor("YourDbChild", "YourTableChild"));
        }

        public static void RegisterTypesFromAppConfig(IUnityContainer container)
        {
            container.LoadConfiguration();
        }

        public static void RegisterTypesByConvention(IUnityContainer container)
        {
//            container.RegisterTypes(
//                AllClasses.FromLoadedAssemblies(),
//                WithMappings.FromMatchingInterface,
//                WithName.Default);

//            container.RegisterTypes(
//                AllClasses.FromLoadedAssemblies(),
//                WithMappings.FromMatchingInterface,
//                WithName.TypeName,
//                WithLifetime.ContainerControlled);

//            container.RegisterTypes(
//                AllClasses.FromLoadedAssemblies(),
//                WithMappings.FromMatchingInterface,
//                WithName.Default,
//                WithLifetime.ContainerControlled);
//            // Provide some additional information for this registration
//            container.RegisterType<YourDatabase>(new InjectionConstructor("YourDb", "YourTable"));

//            container.RegisterTypes(
//                AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "Unity.Bi"),
//                WithMappings.FromMatchingInterface,
//                WithName.Default,
//                WithLifetime.ContainerControlled);

//            container.RegisterTypes(
//                AllClasses.FromLoadedAssemblies(),
//                WithMappings.FromMatchingInterface,
//                getInjectionMembers: t => new InjectionMember[]
//                {
//                    new InjectionConstructor("YourDb", "YourTable")
//                });

//            container.AddNewExtension<Interception>();
//            container.RegisterTypes(
//                AllClasses.FromLoadedAssemblies().Where(
//                    t => t.Namespace == "Unity.Bi"),
//                WithMappings.FromMatchingInterface,
//                getInjectionMembers: t => new InjectionMember[]
//                {
//                    new Interceptor<VirtualMethodInterceptor>(),
//                    new InterceptionBehavior<LoggingInterceptionBehavior>()
//                });

            container.RegisterTypes(
                new[] { typeof(Database), typeof(MyDatabase) },
                t => new[] { typeof(IDatabase) },
                overwriteExistingMappings: true);
        }

        public static void RegisterTypesLifetimeManager(IUnityContainer container)
        {
            container.RegisterType<IDatabase, MyDatabase>(new ContainerControlledLifetimeManager());
            container.RegisterType<IDatabase, Database>("Database", new ContainerControlledLifetimeManager());
            container.RegisterType<IDatabase, HisDatabase>("HisDatabase", new ContainerControlledLifetimeManager(), 
                new InjectionProperty("Name", "HisName"));
            container.RegisterType<IDatabase, YourDatabase>(new ContainerControlledLifetimeManager(), 
                new InjectionConstructor("YourDb", "YourTable"));

            //            var db = container.Resolve<IDatabase>();
            //            var dao = container.Resolve<KundeDao>();

            //            container.RegisterType<IDatabase, YourDatabase>(new InjectionConstructor("YourDb", "YourTable"));
            //            var dao = container.Resolve<KundeDao>();

            //            var account = ApplicationConfiguration.GetStorageAccount("DataConnectionString");
            //            container.RegisterInstance(account);

            // container.RegisterType(typeof(IList<>), typeof(List<>), new InjectionConstructor());
            //            var list = container.Resolve<IList<string>>();

            //            container.RegisterType(typeof(IList<>), typeof(List<>), new InjectionConstructor(typeof(int)));
            //            var list = container.Resolve<IList<string>>(new ParameterOverride("capacity", 5));

            //            var container = new UnityContainer();
            //            container.RegisterType(typeof(IList<>), typeof(List<>), "standard", new InjectionConstructor());
            //            container.RegisterType(typeof(IList<>), typeof(List<>), "capacity", new InjectionConstructor(5));
            //            var list1 = container.Resolve<IList<string>>("standard");
            //            var list2 = container.Resolve<IList<string>>("capacity");
        }
    }
}
