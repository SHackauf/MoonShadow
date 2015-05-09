using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DepartmentModul.Models;

using Microsoft.Practices.Prism.Commands;

namespace DepartmentModul.ViewModels
{
    public sealed class DepartmentDetailViewModel
    {
        public DepartmentDetailViewModel()
        {
            Department = new Department { Id = -1, Name = "Development" };

            SaveCommand = new DelegateCommand(OnSave);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        public IDepartment Department { get; set; }

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        private void OnSave()
        {
        }

        private void OnCancel()
        {
        }
    }
}
