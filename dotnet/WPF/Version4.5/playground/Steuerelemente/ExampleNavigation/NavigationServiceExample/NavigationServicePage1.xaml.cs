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

namespace ExampleNavigation.NavigationServiceExample
{
    public partial class NavigationServicePage1 : Page
    {
        private readonly NavigatingCancelEventHandler _onNavigating = (sender, args) => MessageBox.Show("Navigating");
        private readonly NavigationProgressEventHandler _onNavigationProgress = (sender, args) => MessageBox.Show("NavigationProgress");
        private readonly NavigatedEventHandler _onNavigated = (sender, args) => MessageBox.Show("Navigated");
        private readonly NavigationStoppedEventHandler _onNavigationStopped = (sender, args) => MessageBox.Show("NavigationStopped");
        private readonly NavigationFailedEventHandler _onNavigationFailed = (sender, args) => MessageBox.Show("NavigationFailed");
        private readonly LoadCompletedEventHandler _onLoadCompleted = (sender, args) => MessageBox.Show("LoadCompleted");
        private readonly FragmentNavigationEventHandler _onFragmentNavigation = (sender, args) => MessageBox.Show("FragmentNavigation");

        public NavigationServicePage1()
        {
            InitializeComponent();


            // NavigationService is set after loaded.
            Loaded += (s, a) =>
                {
                    NavigationService.Navigating += _onNavigating;
                    NavigationService.NavigationProgress += _onNavigationProgress;
                    NavigationService.Navigated += _onNavigated;
                    NavigationService.NavigationStopped += _onNavigationStopped;
                    NavigationService.NavigationFailed += _onNavigationFailed;
                    NavigationService.LoadCompleted += _onLoadCompleted;
                    NavigationService.FragmentNavigation += _onFragmentNavigation;
                };
            Unloaded += (s, a) =>
                {
                    if (NavigationService != null)
                    {
                        NavigationService.Navigating -= _onNavigating;
                        NavigationService.NavigationProgress -= _onNavigationProgress;
                        NavigationService.Navigated -= _onNavigated;
                        NavigationService.NavigationStopped -= _onNavigationStopped;
                        NavigationService.NavigationFailed -= _onNavigationFailed;
                        NavigationService.LoadCompleted -= _onLoadCompleted;
                        NavigationService.FragmentNavigation -= _onFragmentNavigation;
                    }
                };
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var page = new NavigationServicePage2("Hello page. NavigationServicePage1 is calling you.");
            NavigationService.Navigate(page);
        }

        private void Hyperlink_PackUri_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("NavigationServiceExample/NavigationServicePage3.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void Hyperlink_Refresh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Refresh();
        }
    }
}
