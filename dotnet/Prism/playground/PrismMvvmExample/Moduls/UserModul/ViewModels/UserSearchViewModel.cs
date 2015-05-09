using System.Collections.ObjectModel;

using UserModul.Models;
using UserModul.Services;

namespace UserModul.ViewModels
{
    public sealed class UserSearchViewModel
    {
        private IUserService _userService;

        public UserSearchViewModel(IUserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<IUser>(_userService.FindUsers());
        }

        public ObservableCollection<IUser> Users { get; private set; }
    }
}
