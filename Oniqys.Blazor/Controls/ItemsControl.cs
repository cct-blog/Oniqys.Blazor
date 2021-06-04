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
            set
            {
                if (_items is INotifyCollectionChanged oldValue)
                {
                    oldValue.CollectionChanged -= OnCollectionChanged;
                }
                _items = value;
                if (_items is INotifyCollectionChanged newValue)
                {
                    newValue.CollectionChanged += OnCollectionChanged;
                }
            }
        }

        void OnCollectionChanged(object s, NotifyCollectionChangedEventArgs e)
        {
            StateHasChanged();
        }
    }
}
