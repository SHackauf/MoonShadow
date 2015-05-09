using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentModul.Models
{
    public interface IDepartment : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
