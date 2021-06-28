using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.Core;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public class ItemsControl<TItem> : ViewComponentBase<TItem>
    {
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        private IList<TItem> _items;

        private WeakCollectionChangedEvent _collectionChanged;

        [Parameter]
        public IList<TItem> Items
        {
            get => _items;
            set => UpdateItems(ref _items, value);
        }

        private void UpdateItems(ref IList<TItem> items, IList<TItem> value)
        {
            if (_collectionChanged != null)
            {
                _collectionChanged.Remove();
                _collectionChanged = null;
            }

            UpdateValue(ref items, value);
            if (_items != null)
            {
                _collectionChanged = WeakCollectionChangedEvent.Create(_items, OnCollectionChanged);
            }
        }

        private void OnCollectionChanged(object source, NotifyCollectionChangedEventArgs args) => Invalidate();

        public ItemsControl()
        {
            Items = new ContentCollection<TItem>();
        }
    }
}
