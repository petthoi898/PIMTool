

using System.Windows.Input;
using PIMTool.Client.Command;
using PIMTool.Client.Store;

namespace PIMTool.Client.Presentation.ViewModel
{
    public class UnexpectedErrorViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public UnexpectedErrorViewModel(NavigationStore navigationStore, string message)
        {
            _navigationStore = navigationStore;
            ErrorMessage = "Unexpected Error Occurs: " + message;
            NavigateProjectListCommand = new NavigateProjectsListCommand(navigationStore);
        }
        public ICommand NavigateProjectListCommand { get; set; }
        public string ErrorMessage { get; set; }
    }
}
