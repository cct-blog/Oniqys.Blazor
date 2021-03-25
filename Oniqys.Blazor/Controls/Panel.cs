using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public class Panel<TComponent, TViewModel> : ViewComponentBase<TViewModel>
    {
        [Parameter]
        public ContentCollection<TComponent> Children { get; set; } = new ContentCollection<TComponent>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Children.CollectionChanged += (s, e) => StateHasChanged();
            Children.PropertyChanged += (s, e) => StateHasChanged();
        }
    }
}
