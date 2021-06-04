﻿using System.Threading.Tasks;

namespace Oniqys.Blazor.ViewModel
{
    public abstract class CommandBase<T> : ContentBase
    {
        public T Parameter { get; set; }

        private bool _canExecute = true;
        public bool CanExecute
        {
            get => _canExecute;
            set => ValueChangeProcess(ref _canExecute, value);
        }

        public abstract void Execute(T parameter);
    }

    public abstract class AsyncCommandBase<T> : ContentBase
    {
        public T Parameter { get; set; }

        private bool _canExecute = true;
        public bool CanExecute
        {
            get => _canExecute;
            set => ValueChangeProcess(ref _canExecute, value);
        }

        public abstract Task Execute(T parameter);
    }

    public abstract class CommandBase : ContentBase
    {
        private bool _canExecute = true;
        public bool CanExecute
        {
            get => _canExecute;
            set => ValueChangeProcess(ref _canExecute, value);
        }

        public abstract void Execute();
    }

    public abstract class AsyncCommandBase : ContentBase
    {
        private bool _canExecute = true;
        public bool CanExecute
        {
            get => _canExecute;
            set => ValueChangeProcess(ref _canExecute, value);
        }

        public abstract Task Execute();
    }
}
