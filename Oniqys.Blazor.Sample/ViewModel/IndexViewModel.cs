using System.Collections.Generic;
using System.ComponentModel;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Sample.ViewModel
{
    public class IndexViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Selectable<string> Item { get; set; } = new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test" };

        public List<Selectable<string>> Items { get; set; } = new()
        {
            new Selectable<string> { IsSelected = true, IsEnabled = false, Content = "Test0" },
            new Selectable<string> { IsSelected = true, IsEnabled = false, Content = "Test1" },
            new Selectable<string> { IsSelected = true, IsEnabled = false, Content = "Test2" },
            new Selectable<string> { IsSelected = false, IsEnabled = true, Content = "Test3" },
            new Selectable<string> { IsSelected = false, IsEnabled = true, Content = "Test4" },
            new Selectable<string> { IsSelected = false, IsEnabled = true, Content = "Test5" },
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test6" },
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test7" },
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test8" },
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test9" },
        };
    }
}
