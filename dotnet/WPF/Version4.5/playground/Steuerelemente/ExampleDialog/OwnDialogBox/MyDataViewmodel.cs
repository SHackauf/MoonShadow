using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDialog.OwnDialogBox
{
    public sealed class MyDataViewmodel : INotifyPropertyChanged
    {
        private string _name;
        private int _age;

        public string Name {
            get { return _name;  }
            set
            {
                if (value == _name)
                    return;
                _name = value;
                OnPropertyChanged();
            }

        }

        public int Age {
            get { return _age;  }
            set
            {
                if (value == _age)
                    return;
                _age = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
