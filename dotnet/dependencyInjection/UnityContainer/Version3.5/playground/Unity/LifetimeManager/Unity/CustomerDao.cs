using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeManager.Unity
{
    interface ICustomerDao
    {
    }

    internal class CustomerDao : ICustomerDao
    {
        public CustomerDao(IKundenDao kundenDao)
        {
            Console.WriteLine("new CustomerDao()");
            this.KundenDao = kundenDao;
        }

        public IKundenDao KundenDao { get; set; }
    }
}
