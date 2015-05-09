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
    /// Interaction logic for ExampleDataTemplateSelctor.xaml
    /// </summary>
    public partial class ExampleDataTemplateSelctor : Page
    {
        public ExampleDataTemplateSelctor()
        {
            InitializeComponent();
            this.DataContext = new PersonsViewModel(new ObservableCollection<PersonViewModel>
                {
                    new PersonViewModel { Id = -1, Firstname = "Andi", Lastname = "Zahn" },
                    new PersonViewModel { Id = 1, Firstname = "Donald", Lastname = "Duck" },
                    new PersonViewModel { Id = -1, Firstname = "Dagobert", Lastname = "Duck" },
                    new PersonViewModel { Id = 3, Firstname = "Gustav", Lastname = "Gans" }
                });
        }
    }

    public class PersonDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item != null && item is PersonViewModel)
            {
                var person = item as PersonViewModel;
                if (person.Id < 0)
                    return element.FindResource("PersonDataTemplate") as DataTemplate;
                return element.FindResource("AlternativPersonDataTemplate") as DataTemplate;
            }

            return null;
        }
    }
}
