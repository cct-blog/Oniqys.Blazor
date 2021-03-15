using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oniqys.Blazor.Controls.Layouter;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public class Panel : ViewComponentBase<ComponentBase>
    {
        [Parameter]
        public ObservableCollection<ComponentBase> Children { get; set; } = new ObservableCollection<ComponentBase>();
    }
}
