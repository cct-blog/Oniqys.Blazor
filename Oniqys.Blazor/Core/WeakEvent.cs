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

    public sealed class WeakPropertyChangedEvent : WeakEventBase<object, PropertyChangedEventArgs>
    {
        private WeakPropertyChangedEvent(object source, Action<object, PropertyChangedEventArgs> handler) : base(source, handler)
            => ((INotifyPropertyChanged)source).PropertyChanged += Handle;

        protected override void Remove(object source) => ((INotifyPropertyChanged)source).PropertyChanged -= Handle;

        static public WeakPropertyChangedEvent Create(object source, Action<object, PropertyChangedEventArgs> handler)
            => source is INotifyPropertyChanged ? new WeakPropertyChangedEvent(source, handler) : null;
    }

    public class WeakCollectionChangedEvent : WeakEventBase<object, NotifyCollectionChangedEventArgs>
    {
        private WeakCollectionChangedEvent(object source, Action<object, NotifyCollectionChangedEventArgs> handler) : base(source, handler)
            => ((INotifyCollectionChanged)source).CollectionChanged += Handle;

        protected override void Remove(object source) => ((INotifyCollectionChanged)source).CollectionChanged -= Handle;

        static public WeakCollectionChangedEvent Create(object source, Action<object, NotifyCollectionChangedEventArgs> handler)
            => source is INotifyCollectionChanged ? new WeakCollectionChangedEvent(source, handler) : null;
    }
}
