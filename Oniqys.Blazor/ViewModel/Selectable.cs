namespace Oniqys.Blazor.ViewModel
{
    /// <summary>
    /// 選択可能なViewModelです。
    /// </summary>
    public partial class Selectable<TContent> : ContentBase
    {
        // TODO : プロパティは自動生成予定

        private bool _isSelected;

        /// <summary>
        /// 選択状態を取得または設定します。
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set => EquatableValueChangeProcess(ref _isSelected, value);
        }

        private bool _isEnabled;

        /// <summary>
        /// 選択状態を変更可能かを取得または設定します。
        /// </summary>
        public bool IsEnabled
        {
            get => _isEnabled;
            set => EquatableValueChangeProcess(ref _isEnabled, value);
        }

        TContent _content;
        /// <summary>
        /// 表示するViewModelを取得または設定します。
        /// </summary>
        public TContent Content
        {
            get => _content;
            set
            {
                // TODO : ここは不完全。本来は比較して異なる場合のみとすべきです。また、INotifyPropertyChangedに対応しなければ不完全です。
                _content = value;
                OnPropertyChanged();
            }
        }
    }
}
