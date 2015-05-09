using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
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

using ExampleDatabinding.Model;
using ExampleDatabinding.ViewModel;

namespace ExampleDatabinding
{
    /// <summary>
    /// Interaction logic for ExampleCollection.xaml
    /// </summary>
    public partial class ExampleCollection : Page
    {
        public ExampleCollection()
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

        private void AddElementClick(object sender, RoutedEventArgs e)
        {
            ((PersonsViewModel)this.DataContext).Persons.Add(new PersonViewModel { Id = -1, Firstname = "Hans", Lastname = "Newton" });
        }

        private void ChangeElementClick(object sender, RoutedEventArgs e)
        {
            // TODO Hacki - Doesn't work
            var model = (PersonsViewModel)this.DataContext;
            if (model.Persons.Count > 0)
                model.Persons[0].Firstname += "Changed";
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var header = e.OriginalSource as GridViewColumnHeader;
            if (header != null)
            {
                var sortedColumn = header.Column.Header as string;

                var persons = CollectionViewSource.GetDefaultView(ListItem2.ItemsSource);
                if (persons != null && persons.CanSort == true)
                {
                    var headerTemplateAscending = Resources["ArrowUp"] as DataTemplate;
                    var headerTemplateDescending = Resources["ArrowDown"] as DataTemplate;
                    
                    if (headerTemplateAscending == null || headerTemplateDescending == null)
                        throw new ConfigurationErrorsException("DataTemplate ArrowUp or ArrowDown not set.");

                    var sortAscending = header.Column.HeaderTemplate == null || headerTemplateDescending == header.Column.HeaderTemplate;
                    persons.SortDescriptions.Clear();
                    persons.SortDescriptions.Add(new SortDescription(sortedColumn, sortAscending ? ListSortDirection.Ascending : ListSortDirection.Descending));
                    header.Column.HeaderTemplate = sortAscending ? headerTemplateAscending : headerTemplateDescending;

                    var listView = e.Source as ListView;
                    var columns = ((GridView)listView.View).Columns;
                    foreach (var column in columns.Where(column => !sortedColumn.Equals(column.Header)))
                    {
                        column.HeaderTemplate = null;
                    }
                }
            }
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            var persons = CollectionViewSource.GetDefaultView(ListItem2.ItemsSource);

            if (((CheckBox)sender).IsChecked.Value)
                persons.Filter += OnFilter;
            else
            {
                persons.Filter -= OnFilter;
            }

            persons.Refresh();
        }

        private bool OnFilter(object o)
        {
            return ((PersonViewModel)o).Id < 2;
        }

        private void GroupingClick(object sender, RoutedEventArgs e)
        {
            var persons = CollectionViewSource.GetDefaultView(ListItem2.ItemsSource);
            persons.GroupDescriptions.Clear();
            if (((CheckBox)sender).IsChecked.Value)
                persons.GroupDescriptions.Add(new PropertyGroupDescription("Lastname"));
            persons.Refresh();
        }
    }
}
