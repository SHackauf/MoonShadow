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

namespace ExampleDialog.OwnDialogBox
{
    public partial class MyModalDialogBox : Window
    {
        public MyModalDialogBox() : this(new MyDataViewmodel { Name = "", Age = 0 }) { }
        public MyModalDialogBox(MyDataViewmodel dataViewmodel)
        {
            InitializeComponent();
            this.DataContext = dataViewmodel;
        }

        public MyDataViewmodel ResultDataViewmodel
        {
            get { return (MyDataViewmodel)this.DataContext; }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid(this))
                return;
            this.DialogResult = true;
        }

        // Validate all dependency objects in a window
        private bool IsValid(DependencyObject node)
        {
            // Check if dependency object was passed
            if (node != null)
            {
                if (Validation.GetHasError(node))
                {
                    if (node is IInputElement) 
                        Keyboard.Focus((IInputElement)node);
                    return false;
                }

                return LogicalTreeHelper.GetChildren(node).OfType<DependencyObject>().All(subnode => IsValid(subnode) != false);
            }

            return true;
        }
    }
}
