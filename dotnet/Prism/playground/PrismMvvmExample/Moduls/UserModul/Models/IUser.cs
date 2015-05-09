using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModul.Models
{
    public interface IUser : IDataErrorInfo, INotifyPropertyChanged
    {
        int Id { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
    }
}
