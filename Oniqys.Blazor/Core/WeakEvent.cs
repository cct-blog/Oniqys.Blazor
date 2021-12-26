using Oniqys.Blazor.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oniqys.Blazor.Core
{
    public abstract class WeakEventBase<T, TArgs>
        where T : class
        where TArgs : EventArgs
    {
        private readonly WeakReference<T> _source;
        private readonly WeakReference<Action<T, TArgs>> _handler;

        public WeakEventBase(T source, Action<T, TArgs> handler)
        {
            _source = new WeakReference<T>(source ?? throw new ArgumentNullException(nameof(source)));
            _handler = new WeakReference<Action<T, TArgs>>(handler ?? throw new ArgumentNullException(nameof(handler)));
        }

        protected void Handle(object sender, TArgs e)
        {
            if (_handler.TryGetTarget(out var handler))
                handler(sender as T, e);
            else
                Remove();
        }

        public void Remove()
        {
            if (_source.TryGetTarget(out var source))
                Remove(source);
        }

        protected abstract void Remove(T source);
    }

    public sealed class WeakPropertyChangedEvent : WeakEventBase<ContentBase, PropertyChangedEventArgs>
    {
        private WeakPropertyChangedEvent(ContentBase source, Action<object, PropertyChangedEventArgs> handler) : base(source, handler)
            => ((INotifyPropertyChanged)source).PropertyChanged += Handle;

        protected override void Remove(ContentBase source) => ((INotifyPropertyChanged)source).PropertyChanged -= Handle;

        static public WeakPropertyChangedEvent Create(ContentBase source, Action<object, PropertyChangedEventArgs> handler)
            => new WeakPropertyChangedEvent(source, handler);
    }

    public class WeakCollectionChangedEvent<T> : WeakEventBase<ContentCollection<T>, NotifyCollectionChangedEventArgs>
        where T : ContentBase
    {
        private WeakCollectionChangedEvent(ContentCollection<T> source, Action<ContentCollection<T>, NotifyCollectionChangedEventArgs> handler) : base(source, handler)
            => ((INotifyCollectionChanged)source).CollectionChanged += Handle;

        protected override void Remove(ContentCollection<T> source) => ((INotifyCollectionChanged)source).CollectionChanged -= Handle;

        static public WeakCollectionChangedEvent<T> Create(ContentCollection<T> source, Action<ContentCollection<T>, NotifyCollectionChangedEventArgs> handler)
            => new WeakCollectionChangedEvent<T>(source, handler);
    }
}
