using System;
using System.Threading.Tasks;

namespace Oniqys.Blazor.ViewModel
{
    public class Command<T> : CommandBase<T>
    {
        private readonly Action<T> _execute;

        public Command(Action<T> execute) => _execute = execute;

        public override void Execute(T parameter) => _execute(Parameter);
    }

    public class AsyncCommand<T> : AsyncCommandBase<T>
    {
        private readonly Func<T, Task> _execute;

        public AsyncCommand(Func<T, Task> execute) => _execute = execute;

        public override async Task Execute(T parameter) => await _execute(Parameter);
    }

    public class Command : CommandBase
    {
        private readonly Action _execute;

        public Command(Action execute) => _execute = execute;

        public override void Execute() => _execute();
    }

    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<Task> _execute;

        public AsyncCommand(Func<Task> execute) => _execute = execute;

        public override async Task Execute() => await _execute();
    }
}
