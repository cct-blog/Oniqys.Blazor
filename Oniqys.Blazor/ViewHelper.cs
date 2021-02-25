using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Oniqys.Blazor
{
    public class ViewHelper : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public ViewHelper(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Oniqys.Blazor.Components/viewHelper.js").AsTask());
        }

        public async ValueTask ScrollElementByIdAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("scrollElementById", id);
        }

        public async ValueTask FocusElementByIdAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("focusElementById", id);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
