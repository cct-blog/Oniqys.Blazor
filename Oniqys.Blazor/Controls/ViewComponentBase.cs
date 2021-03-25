using Microsoft.AspNetCore.Components;
using System.ComponentModel;

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
            set
            {
                if (_dataContext is INotifyPropertyChanged oldValue)
                    oldValue.PropertyChanged -= OnPropertyChanged;

                _dataContext = value;
                if (_dataContext is INotifyPropertyChanged newValue)
                    newValue.PropertyChanged += OnPropertyChanged;

                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(DataContext)));
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_initialized)
                StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _initialized = true;
        }
    }
}
