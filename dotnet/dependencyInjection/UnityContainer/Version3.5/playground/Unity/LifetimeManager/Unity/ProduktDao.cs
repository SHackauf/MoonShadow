using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeManager.Unity
{
    interface IProduktDao
    {         
    }

    class ProduktDao : IProduktDao
    {
        public ProduktDao()
        {
            Console.WriteLine("new ProduktDao()");
        }
    }
}
