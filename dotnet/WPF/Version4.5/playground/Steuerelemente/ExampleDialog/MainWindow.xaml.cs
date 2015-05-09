using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ExampleDialog.FileDialog;
using ExampleDialog.MessageBoxExample;
using ExampleDialog.OwnDialogBox;
using ExampleDialog.PrintDialogExample;

namespace ExampleDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
                        var window = new MessageBoxExamples { Owner = this };
                        window.Show();
                    }
                    break;
                case "Button1":
                    {
                        new FileDialogExamples{ Owner = this }.Show();
                    }
                    break;
                case "Button2":
                    {
                        new PrintDialogExamples { Owner = this }.Show();
                    }
                    break;
                case "Button3":
                    {
                        var data = new MyDataViewmodel { Age = 0, Name = "" };
                        var dialog = new MyModalDialogBox(data) { Owner = this };
                        if (dialog.ShowDialog() == true)
                        {
                            data = dialog.ResultDataViewmodel;
                            MessageBox.Show(string.Format("Ok was pressed [Name: {0}][Age: {1}]", data.Name, data.Age));
                        }
                        else
                            MessageBox.Show("Cancel was pressed");
                    }
                    break;
                case "Button4":
                    {
                        var data = new MyDataViewmodel { Age = 0, Name = "" };
                        data.PropertyChanged += (o, args) =>
                            {
                                var dataNew = (MyDataViewmodel)o;
                                MessageBox.Show(string.Format("Change MyData [Name: {0}][Age: {1}]", dataNew.Name, dataNew.Age));
                            };
                        var dialog = new MyModelessDialogBox(data) { Owner = this };
                        dialog.Show();
                    }
                    break;
            }
        }

        public void OnChange(object sender, PropertyChangedEventArgs e)
        {
        
        }
    }
}
