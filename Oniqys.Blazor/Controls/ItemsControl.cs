using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Oniqys.Blazor.Controls
{
    public partial class ItemsControl<TItem> : ViewComponentBase<TItem>
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
    }
}
