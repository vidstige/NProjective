using System;
using System.Windows.Input;

namespace KinectICP.ViewModels
{
    class DelegatingCommand: ICommand
    {
        private Action<object> _action;
        
        public event EventHandler CanExecuteChanged;

        public DelegatingCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
