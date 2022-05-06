
using PIMTool.Client.Presentation.ViewModel;
using PIMTool.Client.Services;

namespace PIMTool.Client.Command
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : BaseViewModel
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
