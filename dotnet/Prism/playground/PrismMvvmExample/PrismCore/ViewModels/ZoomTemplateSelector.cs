using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismCore.ViewModels
{
    public class ZoomTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ZoomInTemplate { get; set; }
        public DataTemplate ZoomOutTemplate { get; set; }
        public ZoomEnum Status { get; set; }

        public ZoomTemplateSelector()
        {
            Status = ZoomEnum.Out;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return Status == ZoomEnum.Out ? ZoomOutTemplate : ZoomInTemplate;
        }

        public enum ZoomEnum { In, Out }
    }
}
