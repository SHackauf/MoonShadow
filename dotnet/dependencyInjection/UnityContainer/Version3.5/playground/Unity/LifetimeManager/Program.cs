using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

namespace LifetimeManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //LifetimeManagerExample.HierarchieExample();
            //LifetimeManagerExample.PerResolveExample();
            //LifetimeManagerExample.ExternalControlledExample();
            LifetimeManagerExample.PerThreadExample();
        }
    }
}
