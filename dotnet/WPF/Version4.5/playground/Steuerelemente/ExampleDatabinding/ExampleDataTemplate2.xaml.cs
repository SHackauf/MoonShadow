using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ExampleDatabinding.ViewModel;

namespace ExampleDatabinding
{
    /// <summary>
    /// Interaction logic for ExampleDataTemplate2.xaml
    /// </summary>
    public partial class ExampleDataTemplate2 : Page
    {
        public ExampleDataTemplate2()
        {
            InitializeComponent();
            this.DataContext = new PersonsViewModel(new ObservableCollection<PersonViewModel>
                {
                    new PersonViewModel { Id = 0, Firstname = "Andi", Lastname = "Zahn" },
                    new PersonViewModel { Id = 1, Firstname = "Donald", Lastname = "Duck" },
                    new PersonViewModel { Id = 2, Firstname = "Dagobert", Lastname = "Duck" },
                    new PersonViewModel { Id = 3, Firstname = "Gustav", Lastname = "Gans" }
                });
        }
    }
}
