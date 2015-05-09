using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Data;

using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

using UserModul.Models;
using UserModul.Services;

namespace UserModul.ViewModels
{
    public class UserListViewModel : BindableBase
    {
        private IUserService _service;

        public ICollectionView Users { get; private set; }

        public UserListViewModel()
        {
            // TODO Hacki - This new must be set from outside.
            //var service = ServiceLocator.Current.GetInstance<IUserService>();
            _service = new UserService();
            Users = new ListCollectionView(new ObservableCollection<IUser>(_service.FindUsers()));
            Users.CurrentChanged += SelectedItemChanged;
        }

        [InjectionConstructor]
        public UserListViewModel(IUnityContainer container)
        {
            // TODO Hacki - This new must be set from outside.
            _service = container.Resolve<IUserService>();
            Users = new ListCollectionView(new ObservableCollection<IUser>(_service.FindUsers()));
            Users.CurrentChanged += SelectedItemChanged;
        }

        [ImportingConstructor]
        public UserListViewModel(IUserService service)
        {
            // TODO Hacki - Wie wird den diese Methode mit Container aufgerufen.
            _service = service;
            Users = new ListCollectionView(new ObservableCollection<IUser>(service.FindUsers()));
            Users.CurrentChanged += SelectedItemChanged;
        }

        // TODO Hacki - How call this contstructor?
        public UserListViewModel(ObservableCollection<IUser> users)
        {
            Users = new ListCollectionView(users);
            Users.CurrentChanged += SelectedItemChanged;
        }

        void Initalize(IUnityContainer container)
        {
            _service = container.Resolve<IUserService>();
        }

        void SelectedItemChanged(object sender, EventArgs e)
        {
            var currentUser = Users.CurrentItem as IUser;
        }
    }
}
