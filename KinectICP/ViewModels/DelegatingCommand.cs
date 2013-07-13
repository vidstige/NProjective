using System;
using System.Windows.Input;

namespace KinectICP.ViewModels
{
    class DelegatingCommand: ICommand
    {
        private Action<object> _action;

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

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
