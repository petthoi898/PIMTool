using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using PIMTool.Client.Presentation.ViewModel;
using PIMTool.Client.Store;
using PIMTool.Client.WebApiClient.Services;
using PIMTool.Common;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.Command
{
    class NavigateEditProjectCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ProjectViewModel _model;

        public NavigateEditProjectCommand(NavigationStore navigationStore, ProjectViewModel projectToEdit)
        {
            _navigationStore = navigationStore;
            _model = projectToEdit;
        }
        public override void Execute(object parameter)
        {
            if (parameter is ProjectViewModel projectVm)
            {
                projectVm.Members = ProjectEmployeeToMembers(projectVm.GetProject().ProjectEmployees);
                var editProject = IoC.Get<NewProjectViewModel>();
                _navigationStore.CurrentViewModel = new NewProjectViewModel(editProject.GetProjectWebApiClient(),
                    editProject.GetGroupWebApiClient(), editProject.GetEmployeeWebApiClient(), _navigationStore, true,
                    projectVm);
            }
        }

        private IList<string> ProjectEmployeeToMembers(IList<ProjectEmployee> projectEmployees)
        {
            IList<string> result = new List<string>();
            foreach (var employee in projectEmployees)
            {
                result.Add(employee.Employee.Visa);
            }

            return result;
        }
    }
}