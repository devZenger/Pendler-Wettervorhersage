using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pendler_Wettervorhersage
{
    internal class DelegateCommand<T> :ICommand
    {
        Predicate<T> canExecuteHdl { get; set; }
        Action<T> executeHdl { get; set; }

        public DelegateCommand(Action<T> executeHdl, Predicate<T> canExecuteHdl = null)
        {
            this.canExecuteHdl = canExecuteHdl;
            if (executeHdl == null)
            {
                throw new ArgumentNullException("executeHdl", "Please specify the command.");
               
            }
            this.executeHdl = executeHdl;
        }
        
        public void RaiseCanExecuteChanged() 
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, null);

        }

        public bool CanExecute(object parameter)
        {
            return canExecuteHdl == null || canExecuteHdl((T)parameter) == true; 
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) 
        {
            if (executeHdl == null) 
            {
                throw new InvalidOperationException("Execute handler is not initialized.");
            }
            if (parameter == null) 
            {
                throw new ArgumentNullException(nameof(parameter), "Parameter cannot be null.");
            
            }
            
            executeHdl((T)parameter);
        }


    }
}
