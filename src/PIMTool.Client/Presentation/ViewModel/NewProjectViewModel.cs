using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using GalaSoft.MvvmLight.CommandWpf;
using PIMTool.Client.Command;
using PIMTool.Client.Store;
using PIMTool.Client.WebApiClient.Services;
using PIMTool.Common.BusinessObjects;
using IoC = PIMTool.Common.IoC;

namespace PIMTool.Client.Presentation.ViewModel
{
    public class NewProjectViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        #region Fields
        private ProjectViewModel _model;
        private BindableCollection<Group> _groups;
        private readonly bool _isEdit;
        private readonly IEnumerable<int> _projectNumbers;
        private readonly NavigationStore _navigationStore;
        private readonly IEnumerable<string> _visaEmployees;
        private readonly IGroupWebApiClient _groupWebApiClient;
        private readonly IProjectWebApiClient _projectWebApiClient;
        private readonly IEmployeeWebApiClient _employeeWebApiClient;
        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion
        #region Properties
        public BindableCollection<Group> Groups => _groups;
        public ProjectViewModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        private int _index;
        public int Index
        {
            get
            {
                if (SelectedGroup == null) return -1;
                return Groups.ToList().FindIndex(x => x.Id == SelectedGroup.Id);
            }
            set
            {
                _index = value;
                OnPropertyChanged(nameof(Index));
            }
        }
        public Group SelectedGroup
        {
            get => _model.Group;
            set
            {
                _model.Group = value;
                OnPropertyChanged(nameof(SelectedGroup));
                //ClearErrors(nameof(SelectedGroup));
            }
        }

        public DateTime? StartDate
        {
            get => _model.StartDate;
            set
            {

                _model.StartDate = value;
                OnPropertyChanged(nameof(StartDate));
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(FinishDate));

                if (StartDate == null)
                {
                    AddErrors(string.Empty, nameof(StartDate));
                    OnErrorsChanged(nameof(StartDate));

                }
                if (StartDate > FinishDate)
                {
                    AddErrors("Start Date can not after Start Date", nameof(StartDate));
                    OnErrorsChanged(nameof(StartDate));
                }
                OnPropertyChanged(nameof(StartDateHasError));
                OnPropertyChanged(nameof(EndDateHasError));

            }
        }
        public DateTime? FinishDate
        {
            get => _model.FinishDate;
            set
            {
                _model.FinishDate = value;
                OnPropertyChanged(nameof(FinishDate));
                ClearErrors(nameof(FinishDate));
                ClearErrors(nameof(StartDate));
                if (FinishDate < StartDate)
                {
                    AddErrors("Finish Date can not before Start Date", nameof(FinishDate));
                    OnErrorsChanged(nameof(FinishDate));
                }
                OnPropertyChanged(nameof(EndDateHasError));
                OnPropertyChanged(nameof(StartDateHasError));
            }
        }
        public bool StartDateHasError => _propertyNameToErrorsDictionary.ContainsKey(nameof(StartDate));
        public bool EndDateHasError => _propertyNameToErrorsDictionary.ContainsKey(nameof(FinishDate));
        public string Name
        {
            get => _model.Name;

            set
            {
                _model.Name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Index));
                Validate(_model.Name, nameof(Name));
                OnPropertyChanged(nameof(HasErrors));
                OnPropertyChanged(nameof(HasErrorName));

            }
        }

        public string Status
        {
            get => _model.Status;
            set
            {
                _model.Status = value;
                OnPropertyChanged(nameof(Status));
                Validate(_model.Status, nameof(Status));
            }
        }
        public string Customers
        {
            get => _model.Customer;
            set
            {
                _model.Customer = value;
                OnPropertyChanged(nameof(Customers));
                Validate(_model.Customer, nameof(Customers));
                OnPropertyChanged(nameof(HasErrors));
               OnPropertyChanged(nameof(HasErrorCustomer));
            }
        }
        public bool HasErrorCustomer => _propertyNameToErrorsDictionary.ContainsKey(nameof(Customers));
        public bool HasErrorName => _propertyNameToErrorsDictionary.ContainsKey(nameof(Name));

        public int ProjectNumber
        {
            get => _model.ProjectNumber;
            set
            {
                _model.ProjectNumber = value;
                OnPropertyChanged(nameof(ProjectNumber));
                ClearErrors(nameof(ProjectNumber));
                if (CheckDuplicateProjectNumber(_model.ProjectNumber))
                {
                    AddErrors(" ", nameof(ProjectNumber));

                }
                if (value > 9999)
                {
                    AddErrors("  ", nameof(ProjectNumber));
                }
                OnPropertyChanged(nameof(HasErrorProjectNumber));
                OnPropertyChanged(nameof(IndexProjectNumberError));
                OnPropertyChanged(nameof(HasErrors));

            }
        }
        public string Members
        {
            get
            {
                if (_model.Members == null)
                {
                    OnPropertyChanged(nameof(InvalidVisa));
                    return null;
                }
                return string.Join(",", _model.Members);
            }
            set
            {
                _model.Members = ConvertToListMembers(value);
                OnPropertyChanged(nameof(Members));
                ValidateMembers();
            }
        }
        
        public bool HasErrorProjectNumber => _propertyNameToErrorsDictionary.ContainsKey(nameof(ProjectNumber));

        public int IndexProjectNumberError => HasErrorProjectNumber &&
                                              _propertyNameToErrorsDictionary[nameof(ProjectNumber)].Last().Length == 1
            ? 1
            : 0;
        public bool HasErrorVisa => _propertyNameToErrorsDictionary.ContainsKey(nameof(Members));
        public int IndexVisaError => HasErrorVisa &&
                                     _propertyNameToErrorsDictionary[nameof(Members)].Last().Length == 1
            ? 1
            : 0;

        public string InvalidVisa => CheckDuplicateVisaMember(_model.Members)
            ? GetDuplicateVisaMember(_model.Members)
            : GetInvalidVisa(_model.Members);

        public bool ShowSummary
        {
            get
            {
                return _propertyNameToErrorsDictionary.Any(x =>
                    x.Key.Contains(nameof(ProjectNumber))
                    || x.Key.Contains(nameof(Name))
                    || x.Key.Contains(nameof(SelectedGroup))
                    || x.Key.Contains(nameof(StartDate))
                );
            }
            set
            {

            }
        }

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();
        public bool IsNew => !_isEdit;
        public string ButtonName => _isEdit ? "Edit Project" : "Create Project";
        public string LabelName => _isEdit ? "Edit Project Information" : "New Project";
        #endregion

        #region Commands
        public ICommand CancelCommand { get; set; }
        public ICommand CreateRelayCommand { get; set; }

        #endregion

        #region Contructors

        public NewProjectViewModel(IProjectWebApiClient webApiClient, IGroupWebApiClient groupWebApiClient, IEmployeeWebApiClient employeeWebApiClient)
        {

            _projectWebApiClient = webApiClient;
            _groupWebApiClient = groupWebApiClient;
            _employeeWebApiClient = employeeWebApiClient;
        }
        public NewProjectViewModel(IProjectWebApiClient webApiClient, IGroupWebApiClient groupWebApiClient,
            IEmployeeWebApiClient employeeWebApiClient, NavigationStore navigation, bool isEdit, ProjectViewModel model = null)
        {
            _isEdit = isEdit;
            _navigationStore = navigation;
            _projectWebApiClient = webApiClient;
            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
            _groups = new BindableCollection<Group>(groupWebApiClient.GetAllGroups());
            if (model == null)
            {
                _model = new ProjectViewModel()
                {
                    Status = "NEW",
                    Group = _groups.First(),
                };
            }
            else
            {
                _model = model;
            }
            SelectedGroup = isEdit ? model.Group : null;
            _projectNumbers = _projectWebApiClient.GetAllProjects().Select(x => x.ProjectNumber);
            _visaEmployees = new List<string>(employeeWebApiClient.GetAllEmployees().Select(x => x.Visa));
            //CreateCommand = new CreateCommand(webApiClient, this, _navigationStore);
            CancelCommand = new CancelCommand(_navigationStore);
            CreateRelayCommand = new RelayCommand(Create);
        }


        #endregion

        #region Functions

        public IProjectWebApiClient GetProjectWebApiClient()
        {
            return _projectWebApiClient;
        }
        public IGroupWebApiClient GetGroupWebApiClient()
        {
            return _groupWebApiClient;
        }
        public IEmployeeWebApiClient GetEmployeeWebApiClient()
        {
            return _employeeWebApiClient;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (_propertyNameToErrorsDictionary.TryGetValue(propertyName, out List<string> _))
            {
                return _propertyNameToErrorsDictionary[propertyName];
            }
            return null;
        }
        private void AddErrors(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }
            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
        private bool CheckValidInput(string input)
        {
            return string.IsNullOrWhiteSpace(input) || input.Length > 50;
        }
        private List<string> ConvertToListMembers(string input)
        {
            return input.Split(',').ToList();
        }
        private bool CheckDuplicateProjectNumber(int projectNumber)
        {
            if (projectNumber == 0) return false;
            return _projectNumbers.Contains(projectNumber);
        }
        private bool CheckInvalidVisaMember(IList<string> listMember)
        {
            foreach (var element in listMember)
            {
                if (!_visaEmployees.Contains(element.Trim())) return true;
            }
            return false;
        }
        private string GetInvalidVisa(IList<string> listMember)
        {
            StringBuilder result = new StringBuilder();
            foreach (var element in listMember)
            {
                if (!_visaEmployees.Contains(element.Trim()))
                {
                    if (result.Length != 0)
                        result.Append(", ");
                    result.Append(element);
                }
            }
            return result.ToString();
        }
        private bool CheckDuplicateVisaMember(IList<string> listMember)
        {
            listMember = listMember.Select(x => x.Trim()).ToList();
            return new HashSet<string>(listMember).Count != listMember.Count;
        }
        private string GetDuplicateVisaMember(IList<string> listMember)
        {
            listMember = listMember.Select(x => x.Trim()).ToList();
            var listDuplicate = listMember.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            return listDuplicate.Count > 0 ? string.Join(", ", listDuplicate) : string.Empty;
        }
        private void ValidateDate(DateTime? date, string propertyName)
        {
            ClearErrors(propertyName);
            if (date == null)
            {
                AddErrors(string.Empty, propertyName);
            }
        }

        private void ValidateGroup(Group selected)
        {
            ClearErrors(nameof(SelectedGroup));
            if (selected == null)
            {
                AddErrors(string.Empty, nameof(SelectedGroup));
            }
        }

        private void ValidateProjectNumber(int projectNumber)
        {
            ClearErrors(nameof(ProjectNumber));
            if (projectNumber == 0 || projectNumber > 9999)
            {
                AddErrors(string.Empty, nameof(ProjectNumber));
            }
            if (CheckDuplicateProjectNumber(_model.ProjectNumber))
            {
                AddErrors(" ", nameof(ProjectNumber));

            }
        }
        private void Validate(string input, string propertyName)
        {
            ClearErrors(propertyName);
            if (string.IsNullOrEmpty(input) || CheckValidInput(input))
            {
                AddErrors(string.Empty, propertyName);
            }
        }

        private void ValidateMembers()
        {
            ClearErrors(nameof(Members));
            if (CheckDuplicateVisaMember(_model.Members))
            {
                AddErrors(" ", nameof(Members));
                OnPropertyChanged(nameof(InvalidVisa));
            }
            else if (CheckInvalidVisaMember(_model.Members))
            {
                AddErrors("  ", nameof(Members));
                OnPropertyChanged(nameof(InvalidVisa));
            }

            var check = string.Join(" ", _model.Members);
            if (string.IsNullOrWhiteSpace(check))
            {
                ClearErrors(nameof(Members));
            }
            OnPropertyChanged(nameof(HasErrorVisa));
            OnPropertyChanged(nameof(IndexVisaError));
            OnPropertyChanged(nameof(HasErrors));
        }
        private bool ValidateToEdit()
        {
            Validate(_model.Name, nameof(Name));
            Validate(_model.Customer, nameof(Customers));
            ValidateDate(_model.StartDate, nameof(StartDate));
            ValidateGroup(_model.Group);
            ValidateMembers();
            return HasErrors;
        }
        public bool ValidateToCreate()
        {
            ValidateProjectNumber(_model.ProjectNumber);
            Validate(_model.Name, nameof(Name));
            Validate(_model.Customer, nameof(Customers));
            ValidateDate(_model.StartDate, nameof(StartDate));
            ValidateGroup(_model.Group);
            ValidateMembers();
            return HasErrors;
        }
        private void Create()
        {
            if (!IsNew) // Edit
            {
                if (ValidateToEdit())
                {
                    OnPropertyChanged(nameof(ShowSummary));
                    return;
                }
                var project = this.Model.GetProject();
                project.Members = ConvertToListMembers(this.Members).Select(x => x.Trim()).ToList();
                _projectWebApiClient.AddNewProject(project);
                MessageBox.Show("Edit Successfully!");
                NavigateToProjectsList();
            }
            else // Create
            {
                if (ValidateToCreate())
                {
                    OnPropertyChanged(nameof(ShowSummary));
                    return;
                }
                var project = this.Model.GetProject();
                project.Members = ConvertToListMembers(this.Members).Select(x => x.Trim()).ToList();
                _projectWebApiClient.AddNewProject(project);
                MessageBox.Show("Success Added!");
                NavigateToProjectsList();
            }
        }
        private void NavigateToProjectsList()
        {
            var projectList = IoC.Get<ProjectsListViewModel>();
            _navigationStore.CurrentViewModel =
                new ProjectsListViewModel(projectList.GetProjectWebApiClient(), _navigationStore);
        }
        #endregion

    }
}
