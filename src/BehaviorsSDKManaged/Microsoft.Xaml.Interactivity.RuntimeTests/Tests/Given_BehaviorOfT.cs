using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xaml.Interactivity;
using Uno.UI.RuntimeTests;

namespace Microsoft.Xaml.Interactivity.RuntimeTests.Tests;

[TestClass]
[RunsOnUIThread]
public class Given_BehaviorOfT
{
	[TestMethod]
	public void When_Attached_To_Wrong_Type_Throws_Localized_Message()
	{
		var behavior = new ButtonBehavior();

		var ex = Assert.ThrowsExactly<InvalidOperationException>(() => behavior.Attach(new Border()));

		// The message comes from Strings.resw through ResourceHelper; an unresolved resource yields an empty format string.
		StringAssert.Contains(ex.Message, typeof(Border).FullName);
		StringAssert.Contains(ex.Message, typeof(Button).FullName);
	}

	private sealed class ButtonBehavior : Behavior<Button>
	{
	}
}
