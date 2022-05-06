using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PIMTool.Client.Command;
using PIMTool.Client.Store;
using PIMTool.Client.WebApiClient.Services;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.Presentation.ViewModel
{
    public class ProjectsListViewModel : BaseViewModel
    {
        #region Fields
        private NavigationStore _navigationStore;
        private ObservableCollection<ProjectViewModel> _projects;
        private readonly ProjectViewModel _model;
        private readonly IProjectWebApiClient _projectWebApiClient;
        #endregion

        #region Commands

        public ICommand DeleteCommand { get; set; }
        public ICommand NavigateEditProjectCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand CheckedBox { get; set; }
        public ICommand DeleteMulti { get; set; }
        public RelayCommand SearchRelayCommand { get; set; }

        public CollectionView ProjectFilterView { get; set; }

        #endregion

        #region Properties
        public ObservableCollection<ProjectViewModel> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }
        public string Name => _model.Name;

        public int ProjectNumber => _model.ProjectNumber;
        public string Status => _model.Status;
        public DateTime? StartDate => _model.StartDate;
        public bool IsChecked
        {
            get => _model.IsCheck;
            set
            {
                _model.IsCheck = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }
        public bool CanDelete => _model.CanDelete;
        public bool HasMultiple => Projects.Count(x => x.IsCheck) > 0;

        private string _fieldSearch;

        public string FieldSearch
        {
            get => _fieldSearch;
            set
            {
                _fieldSearch = value;
                OnPropertyChanged(nameof(FieldSearch));
            }
        }
        private string _statusSearch;
        public string StatusSearch
        {
            get => _statusSearch;
            set
            {
                _statusSearch = value;
                OnPropertyChanged(nameof(StatusSearch));
            }
        }
        public int NumberSelectedItem => Projects.Count(x => x.IsCheck);

        private ProjectViewModel _selectedProject;
        public ProjectViewModel SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }
        public IList<ProjectViewModel> ProjectsToDeleteMulti => Projects.Where(x => x.IsCheck == true && x.CanDelete == true).ToList();
        #endregion

        #region Funtions
        public void FilterData()
        {
            CollectionViewSource.GetDefaultView(Projects).Refresh();
            ProjectFilterView.SortDescriptions.Add(new SortDescription("ProjectNumber", ListSortDirection.Ascending));

        }
        public bool OnFilterTrigger(object item)
        {

            if (string.IsNullOrWhiteSpace(FieldSearch) && string.IsNullOrWhiteSpace(StatusSearch))
            {
                return true;
            }
            else
            {
                Dictionary<string, string> search = new Dictionary<string, string>();
                search.Add("field", FieldSearch);
                search.Add("status", StatusSearch);
                var projectFilteredByServer = _projectWebApiClient.SearchProjects(search);
                if (projectFilteredByServer.Count > 300)
                {
                    projectFilteredByServer = projectFilteredByServer.Take(300).ToList();
                }
                if (item is ProjectViewModel projectVM)
                {
                    if (ProjectInFiltered(projectFilteredByServer, projectVM.Id))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        private bool ProjectInFiltered(IList<Project> list, int projectId)
        {
            return list.Any(x => x.Id == projectId);
        }

        private void DeleteRow()
        {
            if (MessageBox.Show("Do you want to delete this project?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _projectWebApiClient.DeleteProject(SelectedProject.GetProject());
                LoadProjects();
            }
            //ViewSource.View.Refresh();
        }
        private void DeleteMultiProjects()
        {
            if (MessageBox.Show("Do you want to delete those projects?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var projects = ProjectsToDeleteMulti.Select(x => x.GetProject()).ToList();
                _projectWebApiClient.DeleteMultiProjects(projects);
                LoadProjects();
            }
            OnPropertyChanged(nameof(HasMultiple));
        }

        private void Checked()
        {
            var projectViewModel = Projects.SingleOrDefault(x => x.ProjectNumber == SelectedProject.ProjectNumber);
            projectViewModel.IsCheck = !projectViewModel.IsCheck;
            OnPropertyChanged(nameof(HasMultiple));
            OnPropertyChanged(nameof(NumberSelectedItem));
        }
        private void LoadProjects()
        {
            Projects.Clear();
            var listProject = _projectWebApiClient.GetAllProjects();
            foreach (var project in listProject)
            {
                Projects.Add(new ProjectViewModel(project));
            }
        }
        public IProjectWebApiClient GetProjectWebApiClient()
        {
            return _projectWebApiClient;
        }
        #endregion

        #region Constructors
        public ProjectsListViewModel(IProjectWebApiClient webApiClient)
        {
            _projectWebApiClient = webApiClient;
        }

        public ProjectsListViewModel(IProjectWebApiClient webApiClient, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _projectWebApiClient = webApiClient;
            _projects = new ObservableCollection<ProjectViewModel>();
            var listProject = _projectWebApiClient.GetAllProjects();
            foreach (var project in listProject)
            {
                _projects.Add(new ProjectViewModel(project));
            }
            DeleteCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(DeleteRow);
            SearchRelayCommand = new RelayCommand(FilterData);
            ProjectFilterView = (CollectionView)CollectionViewSource.GetDefaultView(Projects);
            ProjectFilterView.Filter = OnFilterTrigger;
            NavigateEditProjectCommand = new NavigateEditProjectCommand(_navigationStore, SelectedProject);
            ResetCommand = new NavigateProjectsListCommand(_navigationStore);
            CheckedBox = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Checked);
            DeleteMulti = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(DeleteMultiProjects);
            ProjectFilterView.SortDescriptions.Add(new SortDescription("ProjectNumber", ListSortDirection.Descending));
        }

        #endregion

    }
}
