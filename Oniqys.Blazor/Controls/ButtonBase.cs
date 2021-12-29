using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oniqys.Blazor.ViewModel;

namespace Oniqys.Blazor.Controls
{
    public abstract class ButtonBase<TViewModel> : ViewComponentBase<TViewModel> where TViewModel : Clickable
    {
        [Parameter]
        public RenderFragment<TViewModel> ChildContent { get; set; }

        [Parameter]
        public string Class { get; set; }

        protected bool IsEnabled => DataContext?.Command?.CanExecute ?? DataContext?.IsEnabled ?? true;

        protected async Task OnClickAsync()
        {
            if (IsEnabled)
            {
                var command = DataContext?.Command;
                if (command != null)
                {
                    await command.ExecuteAsync();
                    StateHasChanged();
                }
            }
        }
    }
}
