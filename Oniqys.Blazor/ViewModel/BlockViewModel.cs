namespace Oniqys.Blazor.ViewModel
{
    public class BlockViewModel<TContent> : ContentBase
    {
        private TContent _content;

        public TContent Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
    }
}
