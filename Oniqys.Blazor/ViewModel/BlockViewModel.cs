using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oniqys.Blazor.ViewModel
{
    public class BlockViewModel<TContent> : ViewModelBase
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
