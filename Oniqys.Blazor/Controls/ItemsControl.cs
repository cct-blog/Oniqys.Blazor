using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public class ItemsControl<TItem> : ViewComponentBase<TItem>
    {
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        private IList<TItem> _items;

        [Parameter]
        public IList<TItem> Items
        {
            get => _items;
            set => UpdateValue(ref _items, value);
        }

        public ItemsControl()
        {
            Items = new ContentCollection<TItem>();
        }
    }
}
