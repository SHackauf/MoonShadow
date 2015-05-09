using System;
using System.Collections.Generic;
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

using ExampleDatabinding.ViewModel;

namespace ExampleDatabinding
{
    /// <summary>
    /// Interaction logic for ExampleValidation.xaml
    /// </summary>
    public partial class ExampleValidation : Page
    {
        public ExampleValidation()
        {
            InitializeComponent();
            this.DataContext = new PersonViewModel { Id = 1, Firstname = "Donald", Lastname = "Duck" };
        }
    }

    public class LastnameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var realValue = value as string;
            Debug.Assert(realValue != null, "realValue != null");

            if (string.IsNullOrWhiteSpace(realValue))
                return new ValidationResult(false, "Lastname is missing.");
            if (realValue.Length > 50)
                return new ValidationResult(false, "Lastname maximal lenght is 50.");
            return new ValidationResult(true, string.Empty);
        }
    }
}
