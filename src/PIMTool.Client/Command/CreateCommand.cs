using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Ninject;
using PIMTool.Client.DependencyInjection;
using PIMTool.Client.Presentation.ViewModel;
using PIMTool.Client.Store;
using PIMTool.Client.WebApiClient.Services;
using PIMTool.Common.BusinessObjects;
using IoC = PIMTool.Common.IoC;

namespace PIMTool.Client.Command
{
    public class CreateCommand : CommandBase
    {
        private readonly IProjectWebApiClient _projectWebApiClient;
        private readonly NewProjectViewModel _newProjectViewModel;
        private readonly NavigationStore _navigationStore;

        public CreateCommand(IProjectWebApiClient webApiClient, NewProjectViewModel newProjectViewModel, NavigationStore navigation)
        {
            _projectWebApiClient = webApiClient;
            _newProjectViewModel = newProjectViewModel;
            _navigationStore = navigation;
            IoC.Clear();
            IoC.Initialize(
                new StandardKernel(new NinjectSettings { LoadExtensions = true }),
                new ClientBindingModule());
        }

        public override void Execute(object parameter)
        {

            var isNew = parameter is bool ? (bool)parameter : false;
            if (!isNew) // Edit
            {
                var project = _newProjectViewModel.Model.GetProject();
                project.Members = ConvertToListMembers(_newProjectViewModel.Members);
                _projectWebApiClient.AddNewProject(project);
                MessageBox.Show("Edit Successfully!");
                NavigateToProjectsList();
            }
            else // Create
            {
                var project = _newProjectViewModel.Model.GetProject();
                project.Members = ConvertToListMembers(_newProjectViewModel.Members);
                _projectWebApiClient.AddNewProject(project);
                MessageBox.Show("Success Added!");
                NavigateToProjectsList();
            }
        }
        private List<string> ConvertToListMembers(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            return input.Split(',').Select(x => x.Trim()).ToList();
        }

        private void NavigateToProjectsList()
        {
            var projectList = IoC.Get<ProjectsListViewModel>();
            _navigationStore.CurrentViewModel =
                new ProjectsListViewModel(projectList.GetProjectWebApiClient(), _navigationStore);
        }
    }
}