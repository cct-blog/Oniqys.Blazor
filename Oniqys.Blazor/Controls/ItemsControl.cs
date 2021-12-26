using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.Core;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public class ItemsControl<TItem> : ViewComponentBase<TItem>
        where TItem : ContentBase
    {
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        private ContentCollection<TItem> _items;

        private WeakCollectionChangedEvent<TItem> _collectionChanged;

        [Parameter]
        public ContentCollection<TItem> Items
        {
            get => _items;
            set => UpdateItems(ref _items, value);
        }

        private void UpdateItems(ref ContentCollection<TItem> items, ContentCollection<TItem> value)
        {
            if (_collectionChanged != null)
            {
                _collectionChanged.Remove();
                _collectionChanged = null;
            }

            UpdateValue(ref items, value);
            if (_items != null)
            {
                _collectionChanged = WeakCollectionChangedEvent<TItem>.Create(_items, OnCollectionChanged);
            }
        }

        private void OnCollectionChanged(object source, NotifyCollectionChangedEventArgs args) => Invalidate();

        public ItemsControl()
        {
            Items = new ContentCollection<TItem>();
        }
    }
}
