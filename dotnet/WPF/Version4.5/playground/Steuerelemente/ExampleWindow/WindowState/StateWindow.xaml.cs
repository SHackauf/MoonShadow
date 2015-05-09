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
using System.Windows.Shapes;

namespace ExampleWindow.WindowState
{
    /// <summary>
    /// Interaction logic for StateWindow.xaml
    /// </summary>
    public partial class StateWindow : Window
    {
        public StateWindow()
        {
            InitializeComponent();
            Label.Content = string.Format("[ShowInTaskbar: {0}][MaxHeight: {1}][MaxWidth: {2}]", 
                ShowInTaskbar, MaxHeight, MaxWidth);
        }
    }
}
