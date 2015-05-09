using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using Microsoft.Practices.Prism.Commands;

namespace PrismCore.ViewModels
{
    public sealed class ZoomViewModel<T> : IZoomViewModel<T> where T : ItemsControl
    {
        public DelegateCommand<T> ZoomCommand { get; private set; }
        public DelegateCommand<T> ZoomInCommand { get; private set; }
        public DelegateCommand<T> ZoomOutCommand { get; private set; }

        public ZoomViewModel()
        {
            this.ZoomCommand = new DelegateCommand<T>(OnZoomClick, CanZoomClick);
            this.ZoomInCommand = new DelegateCommand<T>(OnZoomInClick, CanZoomInClick);
            this.ZoomOutCommand = new DelegateCommand<T>(OnZoomOutClick, CanZoomOutClick);
        }

        private bool CanZoomOutClick(T control)
        {
            if (control != null)
            {
                var selector = (ZoomTemplateSelector)control.ItemTemplateSelector;
                return selector.Status != ZoomTemplateSelector.ZoomEnum.Out;
            }
            return true;
        }

        private void OnZoomOutClick(T control)
        {
            var selector = (ZoomTemplateSelector)control.ItemTemplateSelector;
            if (selector.Status != ZoomTemplateSelector.ZoomEnum.Out)
            {
                selector.Status = ZoomTemplateSelector.ZoomEnum.Out;
                control.Items.Refresh();
            }
        }

        private bool CanZoomInClick(T control)
        {
            if (control != null)
            {
                var selector = (ZoomTemplateSelector)control.ItemTemplateSelector;
                return selector.Status != ZoomTemplateSelector.ZoomEnum.In;
            }
            return true;
        }

        private void OnZoomInClick(T control)
        {
            var selector = (ZoomTemplateSelector)control.ItemTemplateSelector;
            if (selector.Status != ZoomTemplateSelector.ZoomEnum.In)
            {
                selector.Status = ZoomTemplateSelector.ZoomEnum.In;
                control.Items.Refresh();
            }
        }

        private bool CanZoomClick(T control)
        {
            return true;
        }

        private void OnZoomClick(T control)
        {
            var selector = (ZoomTemplateSelector)control.ItemTemplateSelector;
            selector.Status = selector.Status == ZoomTemplateSelector.ZoomEnum.In ? ZoomTemplateSelector.ZoomEnum.Out : ZoomTemplateSelector.ZoomEnum.In;
            control.Items.Refresh();
        }
    }
}
