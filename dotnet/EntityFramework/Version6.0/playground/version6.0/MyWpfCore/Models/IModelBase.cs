using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfCore.Models
{
    public interface IModelBase : INotifyDataErrorInfo, INotifyPropertyChanged
    {
    }
}
