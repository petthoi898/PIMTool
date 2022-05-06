using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Client.Presentation.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private string _fieldSearch;
        private string _statusSearch;
        public SearchViewModel()
        {
            _fieldSearch = "";
            _statusSearch = "";
        }
        public string FieldSearch
        {
            get => _fieldSearch;
            set
            {
                _fieldSearch = value;
                OnPropertyChanged(nameof(FieldSearch));
            }
        }

        public string StatusSearch
        {
            get => _statusSearch;
            set
            {
                _statusSearch = value;
                OnPropertyChanged(nameof(StatusSearch));
            }
        }
    }
}
