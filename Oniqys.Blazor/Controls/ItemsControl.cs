using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.Core;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public class ItemsControl<DataType> : ViewComponentBase<DataType>
        where DataType : ContentBase
    {
        [Parameter]
        public RenderFragment<DataType> ItemTemplate { get; set; }

        private ContentCollection<DataType> _items;

        private WeakCollectionChangedEvent<DataType> _collectionChanged;

        [Parameter]
        public ContentCollection<DataType> Items
        {
            get => _items;
            set => UpdateItems(ref _items, value);
        }

        private void UpdateItems(ref ContentCollection<DataType> items, ContentCollection<DataType> value)
        {
            if (_collectionChanged != null)
            {
                _collectionChanged.Remove();
                _collectionChanged = null;
            }

            UpdateValue(ref items, value);
            if (_items != null)
            {
                _collectionChanged = WeakCollectionChangedEvent<DataType>.Create(_items, OnCollectionChanged);
            }
        }

        private void OnCollectionChanged(object source, NotifyCollectionChangedEventArgs args) => Invalidate();

        public ItemsControl()
        {
            Items = new ContentCollection<DataType>();
        }
    }
}
