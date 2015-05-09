using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using Unity.Bi;
using Unity.Model;

namespace Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                //RegisterUtils.RegisterTypes(container);
                //MyUnityContainerUtils.RegisterTypesFromAppConfig(container);
                //MyUnityContainerUtils.RegisterTypesByConvention(container);
                RegisterUtils.RegisterTypesLifetimeManager(container);

                WriteUtils.WriteRegister(container);

                ResolveUtils.Resolve(container);

                Console.ReadLine();
            }
        }
    }
}
