using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ExampleNavigation.HyperlinkExample
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class HyperlinkPage1 : Page
    {
        public HyperlinkPage1()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
