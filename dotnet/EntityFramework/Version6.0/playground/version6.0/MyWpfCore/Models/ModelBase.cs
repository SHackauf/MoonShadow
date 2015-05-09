using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MyWpfCore.Models
{
    public abstract class ModelBase : IModelBase
    {

        #region INotifyDataErrorInfo
        private readonly Dictionary<string, IEnumerable<string>> _errorsContainer = new Dictionary<string, IEnumerable<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        protected virtual void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsContainer.ContainsKey(propertyName) ? _errorsContainer[propertyName] : new List<string>();
        }

        public bool HasErrors
        {
            get { return _errorsContainer.Values.Select(error => error.Any()).FirstOrDefault(); }
        }

        protected virtual bool ValidateProperty<T>(T value, string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                var propertyInfo = this.GetType().GetRuntimeProperty(propertyName);
                if (propertyInfo == null)
                    throw new ArgumentException("Invalid property name", propertyName);

                var propertyErrors = new List<ValidationResult>();
                Validator.TryValidateProperty(value, new ValidationContext(this) { MemberName = propertyName }, propertyErrors);
                var errors = Enumerable.ToList<string>(propertyErrors.Select(validationResult => validationResult.ErrorMessage));
                _errorsContainer.Add(propertyInfo.Name, errors);
                OnErrorsChanged(propertyName); // TODO Hacki - Called everytime. Best way call only when the errors really changed. 
                return errors.Count > 0;
            }
            return false;
        }

        #endregion
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (storage == null || !storage.Equals(value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
                ValidateProperty(value, propertyName);
                return true;
            }

            return false;
        }

        #endregion
    }
}
