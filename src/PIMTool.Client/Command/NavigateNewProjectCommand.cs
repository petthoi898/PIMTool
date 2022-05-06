using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMTool.Client.Presentation.ViewModel;
using PIMTool.Client.Store;
using PIMTool.Common;

namespace PIMTool.Client.Command
{
    class NavigateNewProjectCommand : CommandBase
    {
        private NavigationStore _navigationStore;

        public NavigateNewProjectCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            var newProject = IoC.Get<NewProjectViewModel>();
            _navigationStore.CurrentViewModel = new NewProjectViewModel(newProject.GetProjectWebApiClient(),
                newProject.GetGroupWebApiClient(), newProject.GetEmployeeWebApiClient(), _navigationStore, false);
        }
    }
}