using Oniqys.Blazor.ViewModel;
using System.Collections.Generic;

namespace Oniqys.Blazor.Sample.ViewModel
{
    public class IndexViewModel : ContentBase
    {
        public Command AddLineCommand { get; init; }

        public Selectable<string> Item { get; set; } = new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test" };

        public IList<Selectable<string>> Items { get; set; } = new ContentCollection<Selectable<string>>
        {
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test1" },
            new Selectable<string> { IsSelected = true, IsEnabled = false, Content = "Test2" },
        };

        public Clickable AddLineButton { get; init; }

        public IndexViewModel()
        {
            AddLineCommand = new Command(() => Items.Add(Item));
            AddLineButton = new Clickable { Command = AddLineCommand, IsEnabled = true };
        }
    }
}
