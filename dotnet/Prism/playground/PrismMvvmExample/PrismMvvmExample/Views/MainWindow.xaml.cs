using System.Windows;

using Microsoft.Practices.Prism.Mvvm;

namespace PrismMvvmExample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
