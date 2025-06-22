using System.Windows.Input;

namespace Pendler_Wettervorhersage
{
    internal class DelegateNoParameter : ICommand
    {
        Func<bool> canExecuteHdl { get; set; }
        Action executeHdl { get; set; }

        public DelegateNoParameter(Action executeHdl, Func<bool>? canExecuteHdl = null)
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
            return canExecuteHdl == null || canExecuteHdl();
        }

        public event EventHandler? CanExecuteChanged;

        public void Execute(object? parameter)
        {
            if (executeHdl == null)
            {
                throw new InvalidOperationException("Execute handler is not initialized.");
            }
            executeHdl();
        }
        private bool AlwaysTrue()
        {
            return true;
        }
    }
}
