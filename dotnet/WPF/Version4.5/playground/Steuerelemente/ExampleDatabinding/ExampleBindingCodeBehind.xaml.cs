using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
using ExampleDatabinding.Utils;

namespace ExampleDatabinding
{
    /// <summary>
    /// Interaction logic for ExampleBindingCodeBehind.xaml
    /// </summary>
    public partial class ExampleBindingCodeBehind : Page
    {
        public ExampleBindingCodeBehind()
        {
            InitializeComponent();
            var person = new Person { Id = 4711, Firstname = "Dieter", Lastname = "Daum" };
            
            IdItem.SetBinding(TextBox.TextProperty, new Binding("Id") { Source = person });
            FirstnameItem.SetBinding(TextBox.TextProperty, new Binding("Firstname") { Source = person });

            LastnameItem.SetBinding(TextBox.TextProperty, new Binding(ReflectionUtils.GetPropertyName<string>(() => person.Lastname)) 
                { Source = person });
        }
    }
}
