using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.UnityExtensions.Regions;
using Microsoft.Practices.ServiceLocation;

using PrismMvvmExample.Views;

namespace PrismMvvmExample
{
    public sealed class MyBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true); 
            RegisterTypeIfMissing(typeof(IModuleInitializer), typeof(ModuleInitializer), true); 
            RegisterTypeIfMissing(typeof(IModuleManager), typeof(ModuleManager), true); 
            RegisterTypeIfMissing(typeof(RegionAdapterMappings), typeof(RegionAdapterMappings), true); 
            RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
            RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true); 
            RegisterTypeIfMissing(typeof(IRegionViewRegistry), typeof(RegionViewRegistry), true); 
            RegisterTypeIfMissing(typeof(IRegionBehaviorFactory), typeof(RegionBehaviorFactory), true); 
            RegisterTypeIfMissing(typeof(IRegionNavigationJournalEntry), typeof(RegionNavigationJournalEntry), false); 
            RegisterTypeIfMissing(typeof(IRegionNavigationJournal), typeof(RegionNavigationJournal), false); 
            RegisterTypeIfMissing(typeof(IRegionNavigationService), typeof(RegionNavigationService), false); 
            RegisterTypeIfMissing(typeof(IRegionNavigationContentLoader), typeof(UnityRegionNavigationContentLoader), true);
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var userModulType = typeof(UserModul.UserModul);
            ModuleCatalog.AddModule(new ModuleInfo(userModulType.Name, userModulType.AssemblyQualifiedName));

            var moduleType = typeof(DepartmentModul.DepartmentModul);
            ModuleCatalog.AddModule(new ModuleInfo(moduleType.Name, moduleType.AssemblyQualifiedName));
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (MainWindow)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // TODO Hacki - Hier die Module hinzufügen
            return new ConfigurationModuleCatalog();
        }
    }
}
