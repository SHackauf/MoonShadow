using System;
using Microsoft.Practices.Unity;

namespace LifetimeManager.Unity
{
    interface IKundenDao
    {
        ICustomerDao CustomerDao { get; set; }
    }

    internal class KundenDao : IKundenDao
    {
        public KundenDao()
        {
            Console.WriteLine("new KundenDao()");
        }

        [Dependency]
        public ICustomerDao CustomerDao { get; set; }
    }
}
