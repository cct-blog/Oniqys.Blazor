using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                newCollection.CollectionChanged -= OnCollectionChanged;

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
