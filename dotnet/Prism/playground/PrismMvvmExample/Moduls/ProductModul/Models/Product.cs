using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrismCore.Models;

namespace ProductModul.Models
{
    public sealed class Product : BaseModel, IProduct
    {
        private int _id;
        private string _name;
        private string _descrption;

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Descrption is missing.")]
        [MaxLength(20, ErrorMessage = "Maximal descrption length is 20.")]
        public string Description
        {
            get { return _descrption; }
            set
            {
                SetProperty(ref _descrption, value);
                OnPropertyChanged(() => Description);
            }
        }
    }
}
