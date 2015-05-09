using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

using EntityFramework.Models;
using EntityFramework.Services;

using MyWpfCore.ViewModels;

namespace EntityFramework.ViewModels
{
    public sealed class MainWindowViewModel
    {
        private readonly IPersonStorage _service;
        private ObservableCollection<IPerson> _persons;

        public ICollectionView Persons { get; private set; }
        public ICommand Search { get; private set; }

        public MainWindowViewModel()
        {
            _service = new PersonStorage();
            Search = new CommandHandler<object>(OnSearch);
            _persons = new ObservableCollection<IPerson>();
            Persons = new ListCollectionView(_persons);
        }

        void OnSearch(object obj)
        {
            var result = _service.FindAll();
            _persons.Clear();
            result.ToList().ForEach(_persons.Add);
        }
    }
}
