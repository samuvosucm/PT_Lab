using System.Windows.Input;

namespace BookLibrary.Presentation.ViewModel.MVVMLight
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool>? canExecute)
        {
            m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            m_CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (m_CanExecute == null)
                return true;
            if (parameter == null)
                return m_CanExecute();
            return m_CanExecute();
        }

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        public virtual void Execute(object parameter)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
            if (m_Execute != null) m_Execute();
        }

        public event EventHandler? CanExecuteChanged;


        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private readonly Action? m_Execute;
        private readonly Func<bool>? m_CanExecute;


    }
}
