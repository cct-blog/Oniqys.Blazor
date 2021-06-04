namespace Oniqys.Blazor.ViewModel
{
    /// <summary>
    /// 選択可能なViewModelです。
    /// </summary>
    public partial class Selectable<TContent> : Selectable
    {
        // TODO : プロパティは自動生成予定

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
