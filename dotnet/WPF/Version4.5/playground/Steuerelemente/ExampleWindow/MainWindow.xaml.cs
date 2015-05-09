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

using ExampleWindow.WindowDarstellung;
using ExampleWindow.WindowLocation;
using ExampleWindow.WindowState;
using ExampleWindow.WindowsActivate;
using ExampleWindow.WindowsClosing;
using ExampleWindow.WindowsZorder;

namespace ExampleWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var source = e.Source as FrameworkElement;
            Debug.Assert(source != null, "Button_Click - source != null");
            switch (source.Name)
            {
                case "Button0":
                    {
                        var window = new ParentChild.ParentWindow { Owner = this };
                        window.Show();
                    }
                    break;
                case "Button1":
                    {
                        var window = new ActivateWindow { Owner = this, ShowActivated = false };
                        window.Show();
                    }
                    break;
                case "Button2":
                    {
                        var window = new ClosingWindow { Owner = this };
                        window.Show();
                    }
                    break;
                case "Button3":
                    {
                        var window1 = new LocationWindowCenterOwner { Owner = this };
                        window1.Show();
                        var window2 = new LocationWindowCenterScreen{ Owner = this };
                        window2.Show();
                        var window3 = new LocationWindowManual{ Owner = this };
                        window3.Show();
                    }
                    break;
                case "Button4":
                    {
                        var window1 = new ZOrderWindowTopmost { Owner = this };
                        window1.Show();
                        var window2 = new ZOrderWindow { Owner = this };
                        window2.Show();
                    }
                    break;
                case "Button5":
                    {
                        var window = new StateWindow { Owner = this };
                        window.Show();
                    }
                    break;
                case "Button6":
                    {
                        var window = new DarstellungWindow { Owner = this };
                        window.Show();
                    }
                    break;
            }
        }
    }
}
