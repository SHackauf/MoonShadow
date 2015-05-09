using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWpfCore.ViewModels
{
    public class CommandHandler<T> : ICommand
    {
        private readonly Action<T> _excecute;
        private readonly Predicate<T> _canExcecute;

        public CommandHandler(Action<T> excecute, Predicate<T> canExcecute = null)
        {
            if (excecute == null)
                throw new ArgumentNullException("excecute");
            _excecute = excecute;
            _canExcecute = canExcecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExcecute == null)
                return true;
            return _canExcecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _excecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
