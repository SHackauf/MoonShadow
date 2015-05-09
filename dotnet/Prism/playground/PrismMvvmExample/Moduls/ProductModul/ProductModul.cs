using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using ProductModul.Services;

namespace ProductModul
{
    public sealed class ProductModul : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ProductModul(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IProductService, ProductService>(new ContainerControlledLifetimeManager());
//            _container.RegisterType<IUserListViewModel, UserListViewModel>();
            //_container.RegisterType<IUserListViewModel, UserListViewModel>();
            //_container.RegisterType<IUserListViewModel, UserListViewModel>(new InjectionConstructor(_container));
            //_container.RegisterType(typeof(IUserListViewModel), typeof(UserListViewModel), new InjectionMember[]);
        }
    }
}
