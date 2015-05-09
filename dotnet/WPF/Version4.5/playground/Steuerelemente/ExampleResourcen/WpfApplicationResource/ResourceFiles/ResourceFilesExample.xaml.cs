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

namespace ExampleResourcen.WpfApplicationResource.ResourceFiles
{
    /// <summary>
    /// Interaction logic for ResourceFilesExample.xaml
    /// </summary>
    public partial class ResourceFilesExample : Page
    {
        public ResourceFilesExample()
        {
            InitializeComponent();
            InitFrame1();
            InitFrame2();
        }

        private void InitFrame1()
        {
            var imageUri = new Uri("WpfApplicationResource/ResourceFiles/Resource/knock.png", UriKind.RelativeOrAbsolute);
            var imageInfo = Application.GetResourceStream(imageUri);
            this.PageImage1.Source = BitmapDecoder.Create(imageInfo.Stream, BitmapCreateOptions.None, BitmapCacheOption.None).Frames[0];

            var pageUri = new Uri("WpfApplicationResource/ResourceFiles/Resource/ResourceFilePage.xaml", UriKind.Relative);
            var page = Application.LoadComponent(pageUri) as Page;
            this.PageFrame1.Content = page;
        }

        private void InitFrame2()
        {
            var imageUri = new Uri("Resource/knock.png", UriKind.Relative);
            this.PageImage2.Source = new BitmapImage(imageUri);

            var pageUri = new Uri("Resource/ResourceFilePage.xaml", UriKind.Relative);
            this.PageFrame2.Source = pageUri;
        }
    }
}
