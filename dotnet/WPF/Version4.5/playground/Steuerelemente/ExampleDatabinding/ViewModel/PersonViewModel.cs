using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using ExampleDatabinding.Annotations;
using ExampleDatabinding.Model;

namespace ExampleDatabinding.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged, IDataErrorInfo, IPerson
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Person _person;

        public PersonViewModel()
        {
            _person = new Person();
        }

        public PersonViewModel(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");
            _person = person;
        }

        public int Id
        {
            get { return _person.Id; }
            set
            {
                if (value == _person.Id)
                    return;
                _person.Id = value;
                OnPropertyChanged();
            }
        }

        public string Firstname
        {
            get { return _person.Firstname; }
            set
            {
                if (value == _person.Firstname)
                    return;
                _person.Firstname = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get { return _person.Lastname; }
            set
            {
                if (value == _person.Lastname)
                    return;
                _person.Lastname = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }

        #endregion
        #region IDataErrorInfo

        public string this[string columnName]
        {
            get 
            {
                if ("Firstname".Equals(columnName))
                {
                    if (string.IsNullOrWhiteSpace(Firstname))
                        return "Firstname is missing.";
                    if (Firstname.Length > 50)
                        return "Firstname maximal lenght is 50.";
                }
                return string.Empty;
            }
        }

        public string Error { get { return string.Empty; } }

        #endregion
    }
}
