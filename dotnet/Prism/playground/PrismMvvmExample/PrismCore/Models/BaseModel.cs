using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.ViewModel;

namespace PrismCore.Models
{
    public abstract class BaseModel : BindableBase, INotifyDataErrorInfo
    {
        protected BaseModel()
        {
            _errorsContainer = new ErrorsContainer<string>(CallErrorsChanged);
        }

        #region INotifyDataErrorInfo
        private readonly ErrorsContainer<string> _errorsContainer;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors { get { return _errorsContainer.HasErrors; } }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsContainer.GetErrors(propertyName);
        }

        protected void CallErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        #endregion
        #region Combine BindableBase and INotifyDataErrorInfo

        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var result = base.SetProperty<T>(ref storage, value, propertyName);
            if (result && !string.IsNullOrEmpty(propertyName))
                ValidateProperty(value, propertyName);

            return result;
        }

        private bool ValidateProperty<T>(T value, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName");

            var propertyInfo = this.GetType().GetRuntimeProperty(propertyName);
            if (propertyInfo == null)
                throw new ArgumentException("Invalid property name", propertyName);

            var propertyErrors = new List<ValidationResult>();
            Validator.TryValidateProperty(value, new ValidationContext(this){MemberName = propertyName}, propertyErrors);
            var errors = Enumerable.ToList<string>(propertyErrors.Select(validationResult => validationResult.ErrorMessage));
            _errorsContainer.SetErrors(propertyInfo.Name, errors);
            return errors.Count > 0;
        }

        #endregion
    }
}
