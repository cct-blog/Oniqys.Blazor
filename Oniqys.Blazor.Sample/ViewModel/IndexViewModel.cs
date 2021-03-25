using Oniqys.Blazor.ViewModel;
using System.Collections.Generic;

namespace Oniqys.Blazor.Sample.ViewModel
{
    public class IndexViewModel : ContentBase
    {
        public Selectable<string> Item { get; set; } = new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test" };

        public IList<Selectable<string>> Items { get; set; } = new List<Selectable<string>>
        { 
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test1" },
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test2" },
        };
    }
}
