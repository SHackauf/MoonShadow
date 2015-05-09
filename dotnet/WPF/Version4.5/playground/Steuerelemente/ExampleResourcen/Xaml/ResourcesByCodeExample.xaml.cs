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

namespace ExampleResourcen.Xaml
{
    /// <summary>
    /// Interaction logic for ResourcesByCodePage.xaml
    /// </summary>
    public partial class ResourcesByCodeExample : Page
    {
        public ResourcesByCodeExample()
        {
            InitializeComponent();
        }

        private void SetColorByCode_Click(object sender, RoutedEventArgs e)
        {
            var black = (Brush)this.FindResource("MyBlackBrush");
            var white = (Brush)this.TryFindResource("MyWhiteBrush") ?? new SolidColorBrush(Colors.Red);
            
            if (SetColorByCodeItem.Foreground.Equals(black))
            {
                SetColorByCodeItem.Foreground = white;
                SetColorByCodeItem.Background = black;
            }
            else
            {
                SetColorByCodeItem.Foreground = black;
                SetColorByCodeItem.Background = white;
            }

            if (SetColorByCodeItem.Foreground.Equals(black))
            {
                PanelItem.SetResourceReference(ForegroundProperty, "MyWhiteBrush");
                PanelItem.SetResourceReference(BackgroundProperty, "MyBlackBrush");
            }
            else
            {
                PanelItem.SetResourceReference(ForegroundProperty, "MyBlackBrush");
                PanelItem.SetResourceReference(BackgroundProperty, "MyWhiteBrush");
            }
        }

        private void ChangeResourceDictionaryCode_Click(object sender, RoutedEventArgs e)
        {
            var dictionary = new ResourceDictionary
                {
                    { "MyBlackBrush", new SolidColorBrush(Colors.Gray) },
                    { "MyWhiteBrush", new SolidColorBrush(Colors.Gold) }
                };
            this.Resources = dictionary;
        }
    }
}
