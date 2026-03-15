using System;
using System.Windows.Input;

namespace KnowledgeBase.WpfApp.Mvvm;

public sealed class RelayCommand : ICommand
{
    private readonly Action? _execute;
    private readonly Action<object?>? _executeWithParameter;
    private readonly Func<bool>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public RelayCommand(Action<object?> executeWithParameter, Func<bool>? canExecute = null)
    {
        _executeWithParameter = executeWithParameter;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    public void Execute(object? parameter)
    {
        if (_executeWithParameter != null)
            _executeWithParameter(parameter);
        else
            _execute?.Invoke();
    }

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}