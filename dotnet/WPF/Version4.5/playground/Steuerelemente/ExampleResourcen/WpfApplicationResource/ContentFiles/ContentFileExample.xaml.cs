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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace ExampleResourcen.WpfApplicationResource.ContentFiles
{
    /// <summary>
    /// Interaction logic for ContentFileExample.xaml
    /// </summary>
    public partial class ContentFileExample : Page
    {
        public ContentFileExample()
        {
            InitializeComponent();

            Example1();
            Example2();
        }

        private void Example1()
        {
            var imageUri = new Uri("Resource/knock.png", UriKind.Relative);
            PageImage2.Source = new BitmapImage(imageUri);
        }

        private void Example2()
        {              
            var imageUri = new Uri("WpfApplicationResource/ContentFiles/Resource/knock.png", UriKind.Relative);
            var imageInfo = Application.GetContentStream(imageUri);
            this.PageImage1.Source = BitmapDecoder.Create(imageInfo.Stream, BitmapCreateOptions.None, BitmapCacheOption.None).Frames[0];
        }
    }
}
