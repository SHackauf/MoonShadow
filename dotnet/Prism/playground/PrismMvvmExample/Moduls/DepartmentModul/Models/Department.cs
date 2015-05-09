using System.ComponentModel.DataAnnotations;

using PrismCore.Models;

namespace DepartmentModul.Models
{
    public sealed class Department : BaseModel, IDepartment
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
                OnPropertyChanged(() => Id);
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is missing.")]
        [MaxLength(20, ErrorMessage = "Maximal name length is 20.")]
        public string Name 
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                OnPropertyChanged(() => Name);
            }
        }
    }
}
