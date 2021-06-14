using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public class Panel<TComponent, TViewModel> : ViewComponentBase<TViewModel>
    {
        private ContentCollection<TComponent> _children;

        [Parameter]
        public ContentCollection<TComponent> Children
        {
            get => _children;
            set => UpdateValue(ref _children, value);
        }

        public Panel()
        {
            Children = new ContentCollection<TComponent>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
