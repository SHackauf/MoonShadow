using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExampleDialog.OwnDialogBox
{
    public class AgeValidationRule : ValidationRule
    {
        private int _minAge;
        private int _maxAge;

        public int MinAge
        {
            get { return this._minAge;  }
            set { this._minAge = value;  }
        }

        public int MaxAge
        {
            get { return this._maxAge; }
            set { this._maxAge = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age;
            if (!int.TryParse((string)value, out age))
            {
                return new ValidationResult(false, "No number.");
            }

            if ((age < _minAge) || (age > _maxAge))
            {
                return new ValidationResult(false, string.Format("Age must be between {0} and {1}.", _minAge, _maxAge));
            }

            return new ValidationResult(true, null);
        }
    }
}
