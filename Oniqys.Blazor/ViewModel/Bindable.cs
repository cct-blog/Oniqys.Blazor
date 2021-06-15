using Oniqys.Blazor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oniqys.Blazor.ViewModel
{
    /// <summary>
    /// 値型をバインドまたは共有するための参照型です。
    /// </summary>
    /// <typeparam name="T">値型を指定します</typeparam>
    public class Bindable<T> : ContentBase
        where T : struct
    {
        private T _value;

        public T Value
        { 
            get => _value; 
            set => ValueChangeProcess(ref _value, value);
        }
    }
}
