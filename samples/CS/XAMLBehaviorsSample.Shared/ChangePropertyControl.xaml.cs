#if WinUI
using Microsoft.UI.Xaml.Controls;
#else
using Windows.UI.Xaml.Controls;
#endif

namespace XAMLBehaviorsSample;

public sealed partial class ChangePropertyControl : UserControl
{
    public ChangePropertyControl()
    {
        this.InitializeComponent();
    }
}
