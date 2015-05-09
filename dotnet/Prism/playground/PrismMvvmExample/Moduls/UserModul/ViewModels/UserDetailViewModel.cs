using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

using UserModul.Models;
using UserModul.Services;

namespace UserModul.ViewModels
{
    public sealed class UserDetailViewModel : BindableBase
    {
        private IUserService _service;
        public UserDetailViewModel()
        {
            _service = new UserService(); // TODO Hacki - Set by Unity!
            User = _service.Find(1) ?? new User { Id = -1, Firstname = string.Empty, Lastname = string.Empty };

            SaveCommand = new DelegateCommand(OnSave);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        public IUser User { get; set; }

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        private void OnSave()
        {
            _service.Save(User);
            // TODO Hacki - Call page
        }

        private void OnCancel()
        {
            // TODO Hacki - Call page
        }
    }
}
