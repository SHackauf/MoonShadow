using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using PrismMvvmExample.ViewModels;

namespace PrismMvvmExample.Converters
{
    public sealed class MenuEventArgsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var args = new MenuEventArgs();
            foreach (var value in values)
            {
                if (value is MenuEnum)
                    args.Menu = (MenuEnum)value;
                else if (value is Panel)
                {
                    var element = value as Panel;
                    if ("WorkingArea".Equals(element.Name))
                        args.WorkingArea = element;
                }
            }
            return args;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var args = parameter as MenuEventArgs;
            return new object[] { args.Menu, args.WorkingArea };
        }
    }
}
