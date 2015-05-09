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
using System.Windows.Shapes;

namespace ExampleWindow.WindowsActivate
{
    /// <summary>
    /// Interaction logic for NotActivateWindow.xaml
    /// </summary>
    public partial class ActivateWindow : Window
    {
        public ActivateWindow()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            LabelHandler.Content = "Activate by handler";
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            LabelHandler.Content = "Deactivate by handler";
        }

        private void window_Activated(object sender, EventArgs e)
        {
            LabelAttribut.Content = "Activate by attribut";
        }

        private void window_Deactivated(object sender, EventArgs e)
        {
            LabelAttribut.Content = "Deactivate by attribut";
        }
    }
}
