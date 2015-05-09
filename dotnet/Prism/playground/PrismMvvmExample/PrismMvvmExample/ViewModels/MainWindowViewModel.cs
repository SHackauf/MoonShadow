using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using DepartmentModul.Views;

using Microsoft.Practices.Prism.Commands;

using ProductModul.Views;

using UserModul.Views;

namespace PrismMvvmExample.ViewModels
{
    public sealed class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.MenuCommand = new DelegateCommand<MenuEventArgs>(OnMenuClick, CanMenuClick);
        }

        public string TestText { get { return "Test Text"; } }

        public DelegateCommand<MenuEventArgs> MenuCommand { get; private set; }

        private Task OnMenuClickAsync(object o)
        {
            // TODO Hacki muss Task liefern
            return null;
        }

        private void OnMenuClick(MenuEventArgs args)
        {
            if (args != null)
            {
                // Enum eintragen.
                switch (args.Menu)
                {
                    case MenuEnum.User:
                        args.WorkingArea.Children.Clear();
                        args.WorkingArea.Children.Add(new UserList()); // TODO Hacki - Container verwenden.
                        break;
                    case MenuEnum.Deparement:
                        args.WorkingArea.Children.Clear();
                        args.WorkingArea.Children.Add(new DepartmentDetail()); // TODO Hacki - Deparmtent einfügen
                        break;
                    case MenuEnum.Product:
                        args.WorkingArea.Children.Clear();
                        args.WorkingArea.Children.Add(new ProductList()); // TODO Hacki - Container verwenden
                        break;
                }
            }
        }

        private bool CanMenuClick(MenuEventArgs args)
        {
            if (args == null)
                return true;
            else
                return true;
            //return "User".Equals(arg);
        }
    }
}
