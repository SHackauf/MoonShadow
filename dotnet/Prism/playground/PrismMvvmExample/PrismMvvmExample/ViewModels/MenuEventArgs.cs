using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismMvvmExample.ViewModels
{
    public sealed class MenuEventArgs
    {
        public MenuEnum Menu { get; set; }
        public Panel WorkingArea { get; set; }
    }

    public enum MenuEnum
    {
        User = 0,
        Deparement = 1,
        Product = 2
    }
}
