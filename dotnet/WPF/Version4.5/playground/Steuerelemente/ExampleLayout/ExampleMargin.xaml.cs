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

namespace ExampleLayout
{
    /// <summary>
    /// Interaction logic for ExampleMargin.xaml
    /// </summary>
    public partial class ExampleMargin : Page
    {
        public ExampleMargin()
        {
            InitializeComponent();
            CodeBehindButton.Margin = new Thickness(10,50,20,0);
        }
    }
}
