namespace Oniqys.Blazor.ViewModel
{
    public class Clickable : ContentBase
    {
        private CommandBase _command;

        /// <summary>
        /// クリック時のコマンドです。
        /// </summary>
        public CommandBase Command
        {
            get => _command;
            set => ObjectChangeProcess(ref _command, value);
        }

        private bool _isEnabled = true;

        /// <summary>
        /// 選択状態を変更可能かを取得または設定します。
        /// </summary>
        /// <remarks>
        /// <see cref="Command"/>が設定されている場合、<see cref="CommandBase.CanExecute"/>が優先されます。
        /// </remarks>
        public bool IsEnabled
        {
            get => _isEnabled;
            set => EquatableValueChangeProcess(ref _isEnabled, value);
        }
    }
}
