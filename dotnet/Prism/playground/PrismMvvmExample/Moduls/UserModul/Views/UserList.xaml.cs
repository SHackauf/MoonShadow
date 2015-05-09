using System.Windows;
using System.Windows.Controls;

using Microsoft.Practices.Prism.Mvvm;

using UserModul.ViewModels;

namespace UserModul.Views
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : UserControl, IView
    {
        public UserList()
        {
            InitializeComponent();
        }
    }
}
