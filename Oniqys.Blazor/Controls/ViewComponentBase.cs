using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    /// <summary>
    /// MVVMのViewとなるコントロール
    /// </summary>
    public abstract class ViewComponentBase<TViewModel> : ComponentBase
    {
        private bool _initialized;

        private TViewModel _dataContext;

        /// <summary>
        /// ViewModelを取得または設定します。
        /// </summary>
        [Parameter]
        public TViewModel DataContext
        {
            get => _dataContext;
            set => UpdateValue(ref _dataContext, value);
        }

        /// <summary>
        /// <see cref="Bindable{T}"/>のValueをバインドします。
        /// </summary>
        /// <remarks>
        /// 1つの値を複数のコンポーネントで共有する場合に使用します。
        /// </remarks>
        /// <typeparam name="T">値型</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public T Bind<T>(Bindable<T> source)
            where T : struct
        {
            return source?.Value ?? default;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _initialized = true;
        }

        protected void UpdateValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (field is INotifyPropertyChanged oldValue)
                oldValue.PropertyChanged -= OnPropertyChanged;

            if (field is INotifyCollectionChanged oldCollection)
                oldCollection.CollectionChanged -= OnCollectionChanged;

            field = value;

            if (field is INotifyCollectionChanged newCollection)
                newCollection.CollectionChanged += OnCollectionChanged;

            if (field is INotifyPropertyChanged newValue)
                newValue.PropertyChanged += OnPropertyChanged;

            OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(object sender, PropertyChangedEventArgs _) => Invalidate();

        protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs _) => Invalidate();

        protected void Invalidate()
        {
            if (_initialized)
                StateHasChanged();
        }
    }
}
