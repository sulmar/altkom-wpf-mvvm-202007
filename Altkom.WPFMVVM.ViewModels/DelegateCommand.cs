using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Altkom.WPFMVVM.ViewModels
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void OnCanExexuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        
        // wymaga .NET Framework 4.x
        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        CommandManager.RequerySuggested += value;
        //    }

        //    remove
        //    {
        //        CommandManager.RequerySuggested -= value;
        //    }
        //}

        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {            
           execute?.Invoke();
        }
    }
}
