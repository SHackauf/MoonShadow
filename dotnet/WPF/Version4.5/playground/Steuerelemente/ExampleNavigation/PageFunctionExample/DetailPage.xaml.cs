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
    public partial class DetailPage : PageFunction<DetailObject>
    {
        public DetailPage(DetailObject data)
        {
            InitializeComponent();
            this.DataContext = data;
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(new ReturnEventArgs<DetailObject>((DetailObject)this.DataContext));
        }

        void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }
    }
}
