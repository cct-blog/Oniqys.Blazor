using System;
using System.Threading.Tasks;

namespace Oniqys.Blazor.ViewModel
{
    public class Command<T> : CommandBase<T>
    {
        private readonly Func<T, Task> _execute;

        public Command(Action<T> execute) => _execute = (p) => { execute(p); return Task.CompletedTask; };

        public Command(Func<T, Task> execute) => _execute = execute;

        public override async Task ExecuteAsync(T parameter) => await _execute(Parameter);
    }

    public class Command : CommandBase
    {
        private readonly Func<Task> _execute;

        public Command(Action execute) => _execute = () => { execute(); return Task.CompletedTask; };

        public Command(Func<Task> execute) => _execute = execute;

        public override async Task ExecuteAsync() => await _execute();
    }
}
