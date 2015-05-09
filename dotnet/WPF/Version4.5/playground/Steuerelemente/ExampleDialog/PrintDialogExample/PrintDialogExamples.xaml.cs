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

namespace ExampleDialog.PrintDialogExample
{
    /// <summary>
    /// Interaction logic for PrintDialogExample.xaml
    /// </summary>
    public partial class PrintDialogExamples : Window
    {
        public PrintDialogExamples()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PrintDialog
                {
                    PageRangeSelection = PageRangeSelection.AllPages, 
                    UserPageRangeEnabled = true
                };
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                // print
            }
        }
    }
}
