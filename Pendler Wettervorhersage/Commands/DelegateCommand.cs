using System.Windows.Input;

namespace Pendler_Wettervorhersage
{
    internal class DelegateCommand<T> : ICommand
    {
        Predicate<T?>? canExecuteHdl { get; set; }
        Action<T?> executeHdl { get; set; }

        public DelegateCommand(Action<T?> executeHdl, Predicate<T?>? canExecuteHdl = null)
        {
            if (canExecuteHdl == null)
                this.canExecuteHdl = AlwaysTrue;
            else
                this.canExecuteHdl = canExecuteHdl;

            if (executeHdl == null)
            {
                throw new ArgumentNullException("executeHdl", "Please specify the command.");

            }
            this.executeHdl = executeHdl;
        }
        
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return canExecuteHdl == null || canExecuteHdl((T?)parameter);
        }

        public event EventHandler? CanExecuteChanged;

        public void Execute(object? parameter)
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

        private bool AlwaysTrue(T? input)
        {
            return true;
        }
        
    }
}
