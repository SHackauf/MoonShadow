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

namespace ExampleNavigation.PageFunctionExample
{
    /// <summary>
    /// Interaction logic for BasicPage.xaml
    /// </summary>
    public partial class BasicPage : Page
    {
        public BasicPage()
        {
            InitializeComponent();
            AddElementItem.Click += new RoutedEventHandler(AddElementClick);
        }

        void AddElementClick(object sender, RoutedEventArgs e)
        {
            var detailPage = new DetailPage(new DetailObject{Name = "Default"});
            detailPage.Return += (s, args) => //ReturnEventArgs<DetailObject>
                {
                    ResultItem.Text += (args == null ? "Canceled" : "Accepted: " + args.Result.Name);
                };
            this.NavigationService.Navigate(detailPage);
        }
    }
}