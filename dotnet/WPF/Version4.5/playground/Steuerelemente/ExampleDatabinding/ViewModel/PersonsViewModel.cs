using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleDatabinding.Model;

namespace ExampleDatabinding.ViewModel
{
    public class PersonsViewModel
    {
        ObservableCollection<PersonViewModel> _persons;

        public PersonsViewModel()
        {
            _persons = new ObservableCollection<PersonViewModel>();
        }

        public PersonsViewModel(ObservableCollection<PersonViewModel> persons)
        {
            _persons = persons;
        }

        public ObservableCollection<PersonViewModel> Persons
        {
            get { return _persons; }
        }
    }
}
