using Microsoft.Xaml.Interactivity;
using System;

#if WinUI
using Microsoft.UI.Xaml;
#else
using Windows.UI.Xaml;
#endif

namespace XAMLBehaviorsSample;

partial class ContentDialogPopUp : DependencyObject, IAction
{
    ContentDialogSample samplecd;

    public object Execute(object sender, object parameter)
    {
        samplecd = new ContentDialogSample();
        ShowCD();
        return null;
    }

    public async void ShowCD()
    {
        await samplecd.ShowAsync();
    }
}
