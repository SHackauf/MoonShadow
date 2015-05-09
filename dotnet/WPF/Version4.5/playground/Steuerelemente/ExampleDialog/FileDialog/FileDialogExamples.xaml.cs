using System;
using System.Collections.Generic;
using System.Diagnostics;
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

using ExampleDialog.MessageBoxExample;

using Microsoft.Win32;

namespace ExampleDialog.FileDialog
{
    /// <summary>
    /// Interaction logic for FileDialogExamples.xaml
    /// </summary>
    public partial class FileDialogExamples : Window
    {
        public FileDialogExamples()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var source = e.Source as FrameworkElement;
            Debug.Assert(source != null, "Button_Click - source != null");
            switch (source.Name)
            {
                case "Button0":
                    {
                        var dialog = new OpenFileDialog
                            {
                                FileName = "Test",   // Default file name
                                DefaultExt = ".txt", // Default file extension
                                Filter = "Text documents (.txt)|*.txt"
                            };

                        bool? result = dialog.ShowDialog();   
                        if (result == true)
                        {
                            MessageBox.Show("Found: " + dialog.FileName);
                        }
                    }
                    break;
                case "Button1":
                    {
                        var dialog = new SaveFileDialog 
                        { 
                            FileName = "Test", // Default file name
                            DefaultExt = ".txt", // Default file extension
                            Filter = "Text documents (.txt)|*.txt" 
                        };
                        bool? result = dialog.ShowDialog();
                        if (result == true)
                        {
                            MessageBox.Show("Found: " + dialog.FileName);
                        }
                    }
                    break;
            }
        }
    }
}
