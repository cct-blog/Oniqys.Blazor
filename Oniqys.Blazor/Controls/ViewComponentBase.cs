using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.Core;
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

        private WeakPropertyChangedEvent _propertyChanged;

        /// <summary>
        /// ViewModelを取得または設定します。
        /// </summary>
        [Parameter]
        public TViewModel DataContext
        {
            get => _dataContext;
            set => UpdateDataContext(value);
        }

        private void UpdateDataContext(TViewModel value)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged.Remove();
                _propertyChanged = null;
            }

            UpdateValue(ref _dataContext, value);
            if (_dataContext != null)
            {
                _propertyChanged = WeakPropertyChangedEvent.Create(_dataContext, OnPropertyChanged);
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _initialized = true;
        }

        protected void UpdateValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            Invalidate();
        }

        protected void OnPropertyChanged(object sender, PropertyChangedEventArgs _) => Invalidate();

        protected void Invalidate()
        {
            if (_initialized)
                StateHasChanged();
        }
    }
}
