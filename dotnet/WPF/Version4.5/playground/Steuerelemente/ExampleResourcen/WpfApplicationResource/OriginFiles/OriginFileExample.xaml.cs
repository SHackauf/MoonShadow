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

namespace ExampleResourcen.WpfApplicationResource.OriginFiles
{
    /// <summary>
    /// Interaction logic for OriginFileExample.xaml
    /// </summary>
    public partial class OriginFileExample : Page
    {
        public OriginFileExample()
        {
            InitializeComponent();
            Example1();
            Example2();
        }

        private void Example1()
        {
            var imageUri = new Uri("pack://siteoforigin:,,,/WpfApplicationResource/OriginFiles/Resource/knock.png", UriKind.Absolute);
            PageImage2.Source = new BitmapImage(imageUri);
        }

        private void Example2()
        {
            var imageUri = new Uri("WpfApplicationResource/OriginFiles/Resource/knock.png", UriKind.Relative);
            var imageInfo = Application.GetRemoteStream(imageUri);
            this.PageImage1.Source = BitmapDecoder.Create(imageInfo.Stream, BitmapCreateOptions.None, BitmapCacheOption.None).Frames[0];
        }
    }
}
