using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using LifetimeManager.Unity;

using Microsoft.Practices.Unity;

namespace LifetimeManager
{
    internal class LifetimeManagerExample
    {
        public static void HierarchieExample()
        {
            Console.WriteLine(" ==> Start ContainerControlledLifetimeManager");
            using (var parent = new UnityContainer())
            {
                // Only one Instance of IDatabase 
                parent.RegisterType<IProduktDao, ProduktDao>(new ContainerControlledLifetimeManager());

                var child1 = parent.CreateChildContainer();
                var child2 = parent.CreateChildContainer();

                var produktParent = parent.Resolve<IProduktDao>();
                var produktChild1 = child1.Resolve<IProduktDao>();
                var produktChild2 = child2.Resolve<IProduktDao>();
            }

            Console.WriteLine(" ==> End ContainerControlledLifetimeManager");
            Console.WriteLine(" ==> Start HierarchicalLifetimeManager");

            using (var parent = new UnityContainer())
            {
                // One Instance per hierachie (total three instances (parent, child1, child2))
                parent.RegisterType<IProduktDao, ProduktDao>(new HierarchicalLifetimeManager());

                var child1 = parent.CreateChildContainer();
                var child2 = parent.CreateChildContainer();

                var produktParent = parent.Resolve<IProduktDao>();
                var produktChild1 = child1.Resolve<IProduktDao>();
                var produktChild2 = child2.Resolve<IProduktDao>();
                produktChild2 = child2.Resolve<IProduktDao>();
            }

            Console.WriteLine(" ==> End HierarchicalLifetimeManager");
            Console.ReadLine();
        }

        public static void PerResolveExample()
        {
            Console.WriteLine(" ==> Start PerResolveLifetimeManager");
            using (var container = new UnityContainer())
            {
                // One Instance per Resolve
                container.RegisterType<ICustomerDao, CustomerDao>();
                container.RegisterType<IKundenDao, KundenDao>(new PerResolveLifetimeManager());

                var kundenDao = container.Resolve<IKundenDao>();
                var customerDao = (CustomerDao)kundenDao.CustomerDao;
                customerDao = (CustomerDao)kundenDao.CustomerDao;
            }

            Console.WriteLine(" ==> End PerResolveLifetimeManager");
            Console.WriteLine(" ==> Start TransientLifetimeManager");

            using (var container = new UnityContainer())
            {
                // One Instance per get
                container.RegisterType<ICustomerDao, CustomerDao>();
                container.RegisterType<IKundenDao, KundenDao>(new TransientLifetimeManager());

                // next step will throw a StackOverflowException because of endless loop 
                var kundenDao = container.Resolve<IKundenDao>();
            }

            Console.WriteLine(" ==> End TransientLifetimeManager");
            Console.ReadLine();
        }

        public static void ExternalControlledExample()
        {
            Console.WriteLine(" ==> Start ExternallyControlledLifetimeManager");
            using (var container = new UnityContainer())
            {
                container.RegisterType<IProduktDao, ProduktDao>(new ExternallyControlledLifetimeManager());

                container.Resolve<IProduktDao>();
                GC.Collect();
                GC.WaitForFullGCComplete();

                var produkt1 = container.Resolve<IProduktDao>();
                var produkt2 = container.Resolve<IProduktDao>();
                produkt1 = null;
                produkt2 = null;

                GC.Collect();
                GC.WaitForFullGCComplete();

                container.Resolve<IProduktDao>();
            }

            Console.WriteLine(" ==> End ExternallyControlledLifetimeManager");
            Console.ReadLine();
        }

        public static void PerThreadExample()
        {
            Console.WriteLine(" ==> Start PerThreadLifetimeManager(");
            using (var container = new UnityContainer())
            {
                container.RegisterType<IProduktDao, ProduktDao>(new PerThreadLifetimeManager());

                Action<int> action = delegate(int sleep)
                    {
                        container.Resolve<IProduktDao>();
                        Thread.Sleep(sleep);
                        container.Resolve<IProduktDao>();
                    };

                var tasks = new List<Task>
                    {
                        Task.Factory.StartNew(() => action(50)),
                        Task.Factory.StartNew(() => action(50)),
                        Task.Factory.StartNew(() => action(50))
                    };
                Task.WaitAll(tasks.ToArray());
            }

            Console.WriteLine(" ==> End PerThreadLifetimeManager(");
            Console.ReadLine();
        }
    }
}
