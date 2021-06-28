using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Oniqys.Blazor.ViewModel
{
    /// <summary>
    /// 変更通知を持つViewModel全ての基底クラス
    /// </summary>
    public abstract class ContentBase : INotifyPropertyChanged
    {
        protected bool ObjectChangeProcess<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            where T : class
        {
            if (field == value) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool EquatableValueChangeProcess<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            where T : struct, IEquatable<T>
        {
            if (field.Equals(value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool ValueChangeProcess<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
