#if WinUI
using Microsoft.UI.Xaml.Controls;
#else
using Windows.UI.Xaml.Controls;
#endif

namespace XAMLBehaviorsSample;

public sealed partial class EventTriggerControl : UserControl
{
    public EventTriggerControl()
    {
        this.InitializeComponent();
    }
}
