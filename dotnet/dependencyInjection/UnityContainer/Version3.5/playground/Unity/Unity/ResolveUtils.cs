using System;

using Microsoft.Practices.Unity;

using Unity.Bi;

namespace Unity
{
    internal class ResolveUtils
    {
        public static void Resolve(UnityContainer container)
        {
            var database = container.Resolve<IDatabase>();
            var databaseMy = container.Resolve<IDatabase>("Database");
            //var list = container.Resolve<IList<string>>();

//            var databaseYour = container.Resolve(typeof(YourDatabase),
//                new DependencyOverride<YourDatabase>(new YourDatabase("DbOverride", "TabOverride")));

            // Parameter Override
            var databaseYour1 = container.Resolve<IDatabase>(
                new ParameterOverride("aDbName", "DbOverride").OnType<YourDatabase>());

            var databaseYour2 = container.Resolve<IDatabase>(
                new ParameterOverrides
                {
                    {"aDbName", "DbOverride"},
                    {"aTablename", "TabOverride"}
                }
                .OnType<YourDatabase>());

            var databaseYour = container.Resolve<IDatabase>();

            var databaseHis = container.Resolve<IDatabase>("HisDatabase", 
                new PropertyOverride("Name", "OverrideName").OnType<HisDatabase>());

            container.RegisterType<IDatabase, MyDatabase>();
            var databaseLazy = container.Resolve<Lazy<IDatabase>>();
            var kundeLazy = databaseLazy.Value.LoadKunde(1);
        }
    }
}
