using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Sample.ViewModel
{
    public class IndexViewModel : ContentBase
    {
        public Selectable<string> Item { get; set; } = new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "Test" };
    }
}
