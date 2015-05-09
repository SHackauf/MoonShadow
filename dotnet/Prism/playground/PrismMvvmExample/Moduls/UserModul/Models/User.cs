using System.ComponentModel;

using Microsoft.Practices.Prism.Mvvm;

using MyUtils;

namespace UserModul.Models
{
    public sealed class User : BindableBase, IUser
    {
        private int _id;
        private string _firstname;
        private string _lastname;

        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
                OnPropertyChanged(() => Id);
            }
        }

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                SetProperty(ref _firstname, value);
                OnPropertyChanged(() => Firstname);
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                SetProperty(ref _lastname, value); 
                OnPropertyChanged(() => Lastname);
            }
        }

        #region IDataErrorInfo

        public string this[string columnName]
        {
            get
            {
                var propertyName = ReflectionUtils.GetPropertyName(() => Firstname);
                if (propertyName.Equals(columnName))
                {
                    if (string.IsNullOrWhiteSpace(_firstname))
                        return propertyName + " is missing.";
                }

                propertyName = ReflectionUtils.GetPropertyName(() => Lastname);
                if (propertyName.Equals(columnName))
                {
                    if (string.IsNullOrWhiteSpace(_lastname))
                        return propertyName + " is missing.";
                }

                return string.Empty;
            }
        }

        public string Error { get { return string.Empty; } }

        #endregion
    }
}
