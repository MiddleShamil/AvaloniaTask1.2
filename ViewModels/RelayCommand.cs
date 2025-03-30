using System.Windows.Input;
using System;
public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    // Реализация события CanExecuteChanged
    public event EventHandler? CanExecuteChanged;

    // Метод для вызова события CanExecuteChanged
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    // Проверка, можно ли выполнить команду
    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute();
    }

    // Выполнение команды
    public void Execute(object? parameter)
    {
        _execute();
    }
}