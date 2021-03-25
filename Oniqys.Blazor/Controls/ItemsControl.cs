using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oniqys.Blazor.Controls
{
    public partial class ItemsControl<TItem> : ViewComponentBase<TItem>
    {
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        private ContentCollection<TItem> _items = new ContentCollection<TItem>();

        [Parameter]
        public IList<TItem> Items { get; set; }

        public ItemsControl()
        {
            _items.CollectionChanged += (s, e) => StateHasChanged();
        }

        protected override Task OnParametersSetAsync()
        {
            _items.Clear();
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    _items.Add(item);
                }
            }

            return base.OnParametersSetAsync();
        }
    }
}
