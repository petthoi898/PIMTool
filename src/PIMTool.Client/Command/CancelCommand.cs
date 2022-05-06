using PIMTool.Client.Store;
using PIMTool.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMTool.Client.Presentation.ViewModel;

namespace PIMTool.Client.Command
{
    public class CancelCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public CancelCommand(NavigationStore navigate)
        {
            _navigationStore = navigate;
        }
        public override void Execute(object parameter)
        {
            var projectsList = IoC.Get<ProjectsListViewModel>();
            _navigationStore.CurrentViewModel =
                new ProjectsListViewModel(projectsList.GetProjectWebApiClient(), _navigationStore);
        }
    }
}