using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWpfCore.Models;

namespace EntityFramework.Models
{
    class Person : ModelBase, IPerson
    {
        private int _id;
        private string _firstname;
        private string _lastname;
        private string _street;
        private string _zip;
        private string _city;
        private string _country;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is missing.")]
        [MaxLength(25, ErrorMessage = "Maximal firstname length is 25.")]
        public string Firstname 
        {
            get { return _firstname;  }
            set { SetProperty(ref _firstname, value); }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname is missing.")]
        [MaxLength(100, ErrorMessage = "Maximal lastname length is 100.")]
        public string Lastname
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }
        
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }
        
        public string Zip
        {
            get { return _zip; }
            set { SetProperty(ref _zip, value); }
        }
        
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
    }
}
