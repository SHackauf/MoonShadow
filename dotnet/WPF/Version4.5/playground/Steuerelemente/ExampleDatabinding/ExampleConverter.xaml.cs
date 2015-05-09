using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ExampleDatabinding
{
    /// <summary>
    /// Interaction logic for ExampleConverter.xaml
    /// </summary>
    public partial class ExampleConverter : Page
    {
        public ExampleConverter()
        {
            InitializeComponent();
            this.DataContext = new DbStyle { BackgroundColor = Colors.Salmon };
        }
    }

    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorBrush = (SolidColorBrush)value;
            return colorBrush.Color;
        }
    }
}
