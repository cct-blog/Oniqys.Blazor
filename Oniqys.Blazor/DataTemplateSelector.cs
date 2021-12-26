using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oniqys.Blazor
{
    public class DataTemplateSelector
    {
        private readonly Dictionary<Type, ComponentBase> _selector;

        public DataTemplateSelector(IReadOnlyDictionary<Type, ComponentBase> selector)
        {
            _selector = new Dictionary<Type, ComponentBase>(selector);
        }

        public ComponentBase GetComponent(Type dataType)
        {
            return _selector.TryGetValue(dataType, out ComponentBase component) ? component : null;
        }
    }
}
