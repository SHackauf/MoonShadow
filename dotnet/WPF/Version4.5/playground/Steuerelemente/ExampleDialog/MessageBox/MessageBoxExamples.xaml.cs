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

namespace ExampleDialog.MessageBoxExample
{
    /// <summary>
    /// Interaction logic for MessageBoxExamples.xaml
    /// </summary>
    public partial class MessageBoxExamples : Window
    {
        public MessageBoxExamples()
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
                        MessageBox.Show("Hier ist eine Message!", "Beispiel - Info Box");
                    }
                    break;
                case "Button1":
                    {
                        MessageBox.Show("Hier ist eine Message!", "Beispiel - Info Box", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case "Button2":
                    {
                        var answer = MessageBox.Show("Do you want!", "Beispiel - Question yes/no", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        switch (answer)
                        {
                            case MessageBoxResult.Yes:
                                MessageBox.Show("Answer was yes");
                                break;
                            case MessageBoxResult.No:
                                MessageBox.Show("Answer was no");
                                break;
                        }
                    }
                    break;
                case "Button3":
                    {
                        var answer = MessageBox.Show("Do you want!", "Beispiel - Question yes/no/cancel", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        switch (answer)
                        {
                            case MessageBoxResult.Yes:
                                MessageBox.Show("Answer was yes");
                                break;
                            case MessageBoxResult.No:
                                MessageBox.Show("Answer was no");
                                break;
                            case MessageBoxResult.Cancel:
                                MessageBox.Show("Answer was cancel");
                                break;
                        }
                    }
                    break;
                case "Button4":
                    {
                        var answer = MessageBox.Show("Do you want!", "Beispiel - Stop ok/cancel", MessageBoxButton.OKCancel, MessageBoxImage.Stop);
                        switch (answer)
                        {
                            case MessageBoxResult.OK:
                                MessageBox.Show("Answer was ok");
                                break;
                            case MessageBoxResult.Cancel:
                                MessageBox.Show("Answer was cancel");
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
