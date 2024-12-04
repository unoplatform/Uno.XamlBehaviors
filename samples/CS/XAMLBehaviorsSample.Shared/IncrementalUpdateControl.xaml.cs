using System.Collections.Generic;

#if WinUI
using Microsoft.UI.Xaml.Controls;
#else
using Windows.UI.Xaml.Controls;
#endif

namespace XAMLBehaviorsSample;

public sealed partial class IncrementalUpdateControl : UserControl
{
    public List<ItemSample> Items;
    public IncrementalUpdateControl()
    {
        this.InitializeComponent();
        Items = new List<ItemSample>();
        gridViewSample.ItemsSource = Items;
        for(int i = 1; i <= 100; i++)
        {
            Items.Add(new ItemSample(i));
        }
    }
}

public class ItemSample
{
    public int Count { get; set; }
    public ItemSample()
    {
        Count = 0;
    }
    public ItemSample(int i)
    {
        Count = i;
    }
}
