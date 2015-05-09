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

namespace ExampleDatabinding
{
    /// <summary>
    /// Interaction logic for ExamplePriorityBinding.xaml
    /// </summary>
    public partial class ExamplePriorityBinding : Page
    {
        public ExamplePriorityBinding()
        {
            InitializeComponent();
            this.DataContext = new List<object>
                {
                    new { Firstname = "Dieter", Lastname = "Daum" },
                    new { Name = "Donald Duck" },
                    new { }
                };
        }
    }
}
