using System;
using System.IO;
using System.Reflection;

namespace LoadDllDynamic
{
    internal sealed class InstanceBuilder
    {
        /// <summary>
        /// Gets the type of the assembly from the given string.
        /// </summary>
        /// <param name="sTypeAndAssembly">The name of the type followed by the name of the assembly name (separated by ',').</param>
        /// <returns>The type of the assembly.</returns>
        public static Type GetType(string sTypeAndAssembly)
        {
            if (null == sTypeAndAssembly)
                throw new ArgumentNullException("sTypeAndAssembly");
            if (0 >= sTypeAndAssembly.Length)
                throw new ArgumentException("type may not be empty", sTypeAndAssembly);

            string[] saTypeAndAssembly = sTypeAndAssembly.Split(',');
            if (null == saTypeAndAssembly || 2 > saTypeAndAssembly.Length)
                throw new ArgumentException(
                    string.Format("invalid type '{0}'. expected 'classname,assemblyname'", sTypeAndAssembly));
            return GetType(saTypeAndAssembly[1], saTypeAndAssembly[0]);
        }

        /// <summary>
        /// Gets the type from the given string.
        /// </summary>
        /// <param name="sAssemblyName">The name of the assembly.</param>
        /// <param name="sTypeName">The name of the type.</param>
        /// <returns>The type of the assembly.</returns>
        public static Type GetType(string sAssemblyName, string sTypeName)
        {
            Assembly oAssembly;
            if (sAssemblyName.Contains("/") || sAssemblyName.Contains("\\"))
            {   // the assembly name is specified as a file name
                sAssemblyName = Environment.ExpandEnvironmentVariables(sAssemblyName);
                if (false == Path.IsPathRooted(sAssemblyName))
                    sAssemblyName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sAssemblyName);

                oAssembly = Assembly.LoadFrom(sAssemblyName);
            }
            else
                oAssembly = Assembly.Load(sAssemblyName);

            return oAssembly.GetType(sTypeName, true);
        }

        /// <summary>
        /// Creates an instance of an object.
        /// </summary>
        /// <param name="sTypeAndAssembly">The name of the type followed by the name of the assembly name (separated by ',').</param>
        /// <returns>An instance of the object.</returns>
        public static object CreateInstance(string sTypeAndAssembly)
        {
            return CreateInstance(sTypeAndAssembly, null);
        }

        /// <summary>
        /// Creates an instance of an object.
        /// </summary>
        /// <param name="sTypeAndAssembly">The name of the type followed by the name of the assembly name (separated by ',').</param>
        /// <param name="aArgs">An array of arguments to be passed to the constructor (can be null).</param>
        /// <returns>An instance of the object.</returns>
        public static object CreateInstance(string sTypeAndAssembly, params object[] aArgs)
        {
            return CreateInstance(GetType(sTypeAndAssembly), aArgs);
        }

        public static object CreateInstance(Type type, params object[] aArgs)
        {
            try
            {
                return Activator.CreateInstance(type,
                                                BindingFlags.CreateInstance
                                                | BindingFlags.Instance
                                                | BindingFlags.Public
                                                | BindingFlags.NonPublic, // we also want internal constructors to be found
                                                null, aArgs, null, null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
