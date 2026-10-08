using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xaml.Interactivity;
using Uno.UI.RuntimeTests;

namespace Microsoft.Xaml.Interactivity.RuntimeTests.Tests;

[TestClass]
[RunsOnUIThread]
public class Given_DataTriggerBehavior
{
	[TestMethod]
	public async Task When_Value_Matches_Invokes_Action()
	{
		// Properties are set directly (no {Binding}), so this only depends on
		// DataBindingHelper.RefreshDataBindingsOnActions walking the action's type.
		var command = new CountingCommand();
		var trigger = new DataTriggerBehavior { Value = true };
		trigger.Actions.Add(new InvokeCommandAction { Command = command });

		var host = new Border { Width = 100, Height = 100 };
		Interaction.GetBehaviors(host).Add(trigger);

		UnitTestsUIContentHelper.Content = host;
		await UnitTestsUIContentHelper.WaitForLoaded(host);

		trigger.Binding = false;
		trigger.Binding = true;
		trigger.Binding = false;
		trigger.Binding = true; // second walk of the same action type hits the property cache

		Assert.AreEqual(2, command.ExecuteCount);
	}

	[TestMethod]
	public async Task When_Bound_Via_DataContext_Invokes_Command()
	{
		var vm = new ViewModel();
		var trigger = new DataTriggerBehavior { Value = true };
		BindingOperations.SetBinding(trigger, DataTriggerBehavior.BindingProperty, new Binding { Path = new PropertyPath(nameof(ViewModel.Flag)) });
		var action = new InvokeCommandAction();
		BindingOperations.SetBinding(action, InvokeCommandAction.CommandProperty, new Binding { Path = new PropertyPath(nameof(ViewModel.Command)) });
		trigger.Actions.Add(action);

		var host = new Border { Width = 100, Height = 100, DataContext = vm };
		Interaction.GetBehaviors(host).Add(trigger);

		UnitTestsUIContentHelper.Content = host;
		await UnitTestsUIContentHelper.WaitForLoaded(host);

		vm.Flag = true;
		await UnitTestsUIContentHelper.WaitForIdle();

		Assert.AreEqual(1, vm.Command.ExecuteCount);
	}

	private sealed class ViewModel : INotifyPropertyChanged
	{
		private bool _flag;

		public event PropertyChangedEventHandler? PropertyChanged;

		public CountingCommand Command { get; } = new();

		public bool Flag
		{
			get => _flag;
			set
			{
				_flag = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Flag)));
			}
		}
	}
}
