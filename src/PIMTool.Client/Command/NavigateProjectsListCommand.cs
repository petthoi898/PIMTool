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
    class NavigateProjectsListCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private ProjectsListViewModel _projectsListViewModel;
        public NavigateProjectsListCommand(NavigationStore navigationStore )
        {
            _navigationStore = navigationStore;
        }
        public NavigateProjectsListCommand(NavigationStore navigationStore, ProjectsListViewModel projectsListViewModel)
        {
            _navigationStore = navigationStore;
            _projectsListViewModel = projectsListViewModel;
        }
        public override void Execute(object parameter)
        {
            //if (_navigationStore.CurrentViewModel.GetType().Name == typeof(ProjectsListViewModel).Name)
            //{
                
            //    return;
            //}    
            var projectsList = IoC.Get<ProjectsListViewModel>();
            _navigationStore.CurrentViewModel =
                new ProjectsListViewModel(projectsList.GetProjectWebApiClient(), _navigationStore);
        }
    }
}