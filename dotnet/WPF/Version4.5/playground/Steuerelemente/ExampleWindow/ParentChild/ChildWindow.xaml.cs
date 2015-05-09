using System.Windows;

namespace ExampleWindow.ParentChild
{
    /// <summary>
    /// Interaction logic for HelloWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        public ChildWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            var owner = this.Owner as ParentWindow;
            if (owner != null)
                owner.CloseChildWindow();
        }
    }
}
