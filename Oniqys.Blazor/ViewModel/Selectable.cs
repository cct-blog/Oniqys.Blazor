namespace Oniqys.Blazor.ViewModel
{
    /// <summary>
    /// 選択可能なViewModelです。
    /// </summary>
    public partial class Selectable : Clickable
    {
        private bool _isSelected;

        /// <summary>
        /// 選択状態を取得または設定します。
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set => EquatableValueChangeProcess(ref _isSelected, value);
        }
    }
}
