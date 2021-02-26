﻿using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace Oniqys.Blazor.Controls
{
    /// <summary>
    /// MVVMのViewとなるコントロール
    /// </summary>
    public abstract class ViewComponentBase<TViewModel> : ComponentBase
    {
        TViewModel _dataContext;
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
                {
                    oldValue.PropertyChanged -= OnPropertyChanged;
                }

                _dataContext = value;
                if (_dataContext is INotifyPropertyChanged newValue)
                {
                    newValue.PropertyChanged += OnPropertyChanged;
                }
                OnPropertyChanged(this, null);
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args) => StateHasChanged();
    }
}