﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Vazby.ViewModel
{
    internal class ParametrizedRelayCommand<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<T> _execute;
        private Func<T,bool> _canExecute;

        public ParametrizedRelayCommand(Action<T> execute, Func<T,bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter == null)
            {
                return true;
            }
            if (parameter == default)
            {
                return _canExecute(default);
            }
            return _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
