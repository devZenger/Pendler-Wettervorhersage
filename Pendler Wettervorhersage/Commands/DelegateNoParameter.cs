using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pendler_Wettervorhersage
{
    internal class DelegateNoParameter : ICommand
    {
        Func<bool> canExecuteHdl { get; set; }
        Action executeHdl { get; set; }

        public DelegateNoParameter(Action executeHdl, Func<bool> canExecuteHdl = null)
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
            return canExecuteHdl == null || canExecuteHdl() == true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (executeHdl == null)
            {
                throw new InvalidOperationException("Execute handler is not initialized.");
            }
            executeHdl();
        }
    }
}
