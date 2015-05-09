
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using UserModul.Services;
using UserModul.ViewModels;

namespace UserModul
{
    public sealed class UserModul : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public UserModul(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
//            _container.RegisterType<IUserListViewModel, UserListViewModel>();
            //_container.RegisterType<IUserListViewModel, UserListViewModel>();
            //_container.RegisterType<IUserListViewModel, UserListViewModel>(new InjectionConstructor(_container));
            //_container.RegisterType(typeof(IUserListViewModel), typeof(UserListViewModel), new InjectionMember[]);
        }
    }
}
