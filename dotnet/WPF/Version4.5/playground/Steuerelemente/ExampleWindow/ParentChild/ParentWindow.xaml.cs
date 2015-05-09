using System;
using System.Windows;

namespace ExampleWindow.ParentChild
{
    /// <summary>
    /// Interaction logic for ParentWindow.xaml
    /// </summary>
    public partial class ParentWindow : Window
    {
        private int _closedWindowsCount = 0;
        public ParentWindow()
        {
            InitializeComponent();
            CalcChildCount();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var child = new ParentChild.ChildWindow { Owner = this };
            child.Closed += (Object o, EventArgs args) => CalcChildCount();
            child.Show();
            CalcChildCount();
        }

        private void CalcChildCount()
        {
            ChildCountLabel.Content = "Child count: " + OwnedWindows.Count;
        }

        public void CloseChildWindow()
        {
            ClosedCountLabel.Content = "Child closed: " + (++_closedWindowsCount);
        }
    }
}
