using System;
using System.Threading.Tasks;

namespace Oniqys.Blazor.ViewModel
{
    public class Command<T> : CommandBase<T>
    {
        private readonly Func<T, Task> _execute;

        public Command(Action<T> execute) => _execute = (p) => { execute(p); return Task.CompletedTask; };

        public Command(Func<T, Task> execute) => _execute = execute;

        public override Task Execute(T parameter) => _execute(Parameter);
    }

    public class Command : CommandBase
    {
        private readonly Func<Task> _execute;

        public Command(Action execute) => _execute = () => { execute(); return Task.CompletedTask; };

        public Command(Func<Task> execute) => _execute = execute;


        public override Task Execute() => _execute();
    }
}
