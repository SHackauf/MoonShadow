using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Models
{
    public interface IBaseModel : INotifyDataErrorInfo, INotifyPropertyChanged
    {
    }
}
