using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using Microsoft.Practices.Prism.Commands;

namespace PrismCore.ViewModels
{
    public interface IZoomViewModel<T> where T : ItemsControl
    {
        DelegateCommand<T> ZoomCommand { get; }
        DelegateCommand<T> ZoomInCommand { get; }
        DelegateCommand<T> ZoomOutCommand { get; }
    }
}
