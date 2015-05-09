using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

using MyWpfCore.ViewModels;

using SimpleExample.Models;
using SimpleExample.Services;

namespace SimpleExample.ViewModels
{
    class MainWindowViewModel : IDisposable
    {
        private readonly IPersonService _service;
        private readonly ObservableCollection<Person> _persons;

        public ICollectionView Persons { get; private set; }
        public ICommand Add { get; private set; }

        public MainWindowViewModel()
        {
            _service = new PersonService();
            Add = new CommandHandler<object>(OnAdd);
            _persons = new ObservableCollection<Person>();
            Persons = new ListCollectionView(_persons);
            Reload();
        }

        private void OnAdd(object obj)
        {
            var person = _service.Save(new Person() { Firstname = "Dieter", Lastname = "Daum" });
            _persons.Add(person);
        }

        private void Reload()
        {
            var result = _service.FindAll();
            _persons.Clear();
            result.ToList().ForEach(_persons.Add);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
