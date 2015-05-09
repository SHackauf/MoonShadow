using System;
using System.Collections.Generic;
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

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateToSelectedItem();
        }

        private void ListBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigateToSelectedItem();
        }

        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigateToSelectedItem();
            }
        }

        private void NavigateToSelectedItem()
        {
            var reportPage = new ExpenseReportPage(this.peopleListBox.SelectedItem);
            var navigationService = this.NavigationService;
            if (navigationService != null)
                navigationService.Navigate(reportPage);
        }
    }
}
