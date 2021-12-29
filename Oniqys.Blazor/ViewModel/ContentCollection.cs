using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Oniqys.Blazor.ViewModel
{
    /// <summary>
    /// 通知型のコレクションです。
    /// </summary>
    /// <remarks>
    /// Countの変更も通知します。またReset時にクリアされた要素の一覧を閲覧可能です。
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class ContentCollection<T> : ContentBase, IList<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private readonly List<T> _list = new();

        public T this[int index]
        {
            get => _list[index];
            set
            {
                var oldItem = _list[index];
                _list[index] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, oldItem, index));
            }
        }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _list.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            OnPropertyChanged(nameof(Count));
        }

        public void Clear()
        {
            var items = _list.ToArray();
            _list.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new List<T>(items)));
            OnPropertyChanged(nameof(Count));
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
            OnPropertyChanged(nameof(Count));
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index >= 0)
            {
                var result = _list.Remove(item);
                if (result)
                {
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                    OnPropertyChanged(nameof(Count));
                }
                return result;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            var item = this[index];
            _list.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
            OnPropertyChanged(nameof(Count));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
            => CollectionChanged?.Invoke(this, args);

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }
    }
}
