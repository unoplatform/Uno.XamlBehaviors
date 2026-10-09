using System;
using System.Windows.Input;

namespace Microsoft.Xaml.Interactivity.RuntimeTests.Tests;

internal sealed class CountingCommand : ICommand
{
	public int ExecuteCount { get; private set; }

	public event EventHandler? CanExecuteChanged { add { } remove { } }

	public bool CanExecute(object? parameter) => true;

	public void Execute(object? parameter) => ExecuteCount++;
}
