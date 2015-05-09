using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Microsoft.Practices.Prism.Commands;

using PrismCore.ViewModels;

using ProductModul.Models;
using ProductModul.Services;

namespace ProductModul.ViewModels
{
    public sealed class ProductListViewModel
    {
        private readonly IProductService _service;
        private readonly ObservableCollection<IProduct> _products;
        private readonly IZoomViewModel<ListBox> _zoomViewModel = new ZoomViewModel<ListBox>();

        public ICollectionView Products { get; private set; }
        public IZoomViewModel<ListBox> ZoomViewModel { get { return _zoomViewModel; } }
        
        public DelegateCommand<IProduct> DeleteCommand { get; private set; }

        public ProductListViewModel()
        {
            _service = new ProductService(); // TODO Hacki - Set by dependency 
            _products = new ObservableCollection<IProduct>(_service.FindAll());
            Products = new ListCollectionView(_products);

            this.DeleteCommand = new DelegateCommand<IProduct>(OnDeleteClick, CanDeleteClick);
        }

        bool CanDeleteClick(IProduct product)
        {
            return product == null || product.Id >= 0;
        }

        void OnDeleteClick(IProduct product)
        {
            if (product != null)
            {
                if (_service.Delete(product))
                    _products.Remove(product);
            }
        }
    }
}
