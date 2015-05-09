using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

namespace Unity
{
    internal class WriteUtils
    {
        public static void WriteRegister(UnityContainer container)
        {
            foreach (ContainerRegistration item in container.Registrations)
            {
                Console.WriteLine(item.GetMappingAsString());
            }
        }

        public static void WriteRegisterDontUse(UnityContainer container)
        {
            Console.WriteLine("Register:");
            var registeredNamesField = typeof(UnityContainer).GetField(
                "registeredNames", BindingFlags.NonPublic | BindingFlags.Instance);
            if (registeredNamesField != null)
            {
                var registeredNames = registeredNamesField.GetValue(container);
                var types = registeredNames.GetType().GetProperty(
                    "RegisteredTypes").GetValue(registeredNames) as IEnumerable<Type>;
                if (types != null)
                {
                    var keysField = registeredNames.GetType().GetField(
                        "registeredKeys", BindingFlags.NonPublic | BindingFlags.Instance);
                    var keys = keysField != null ? keysField.GetValue(registeredNames)
                        as Dictionary<Type, List<string>> : null;
                    foreach (var type in types)
                    {
                        Console.WriteLine("   " + type);
                        if (keys != null)
                        {
                            foreach (var key in keys[type])
                            {
                                Console.WriteLine("      " + key);
                            }
                        }
                    }
                }
            }
        }
    }

    static class ContainerRegistrationsExtension
    {
        public static string GetMappingAsString(this ContainerRegistration registration)
        {   
            var regType = ToString(registration.RegisteredType);

            var mapTo = ToString(registration.MappedToType);
            mapTo = mapTo != regType ? " -> " + mapTo : string.Empty;

            var regName = registration.Name ?? "[default]";
            
            var lifetime = registration.LifetimeManagerType.Name;
            lifetime = lifetime.Substring(0, lifetime.Length - "LifetimeManager".Length);

            return string.Format("+ {0}{1} '{2}' {3}", regType, mapTo, regName, lifetime);
        }

        private static string ToString(Type type)
        {
            return type.Name + GetGenericArgumentsList(type);
        }
        
        private static string GetGenericArgumentsList(Type type)
        {
            if (type.GetGenericArguments().Length == 0) return string.Empty;

            var result = new StringBuilder();
            foreach (Type genArg in type.GetGenericArguments())
            {
                if (result.Length > 0) 
                    result.Append(", ");
                result.Append(genArg.Name);

                if (genArg.GetGenericArguments().Length > 0)
                    result.Append(GetGenericArgumentsList(genArg));
            }
            return "<" + result + ">";
        }
    }
}
