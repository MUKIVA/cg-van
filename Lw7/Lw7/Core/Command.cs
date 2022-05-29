using System;
using System.Windows.Input;

namespace Lw7.Core
{
    public class Command : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute; 
        public Command(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object? parameter) => (_canExecute == null || _canExecute(parameter));

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

    }
}
