using PIMTool.Common.BusinessObjects;
using System;
using System.Collections.Generic;
using PIMTool.Client.WebApiClient.Services;

namespace PIMTool.Client.Presentation.ViewModel
{
    public class ProjectViewModel : BaseViewModel
    {
        
        public ProjectViewModel(Project model)
        {
            _model = model;
        }

        public ProjectViewModel()
        {
            _model = new Project()
            {
                Status = "NEW"
            };
        }

        private Project _model;

        public int Id
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int ProjectNumber
        {
            get => _model.ProjectNumber;
            set
            {
                _model.ProjectNumber = value;
                OnPropertyChanged(nameof(ProjectNumber));
            }
        }
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Status
        {
            get
            {
                return _model.Status;
            }
            set
            {
                _model.Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string Customer
        {
            get
            {
                return _model.Customer;
            }
            set
            {
                _model.Customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        public DateTime? StartDate
        {
            get
            {
                return _model.StartDate;
            }
            set
            {
                _model.StartDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime? FinishDate
        {
            get
            {
                return _model.FinishDate;
            }
            set
            {
                _model.FinishDate = value;
                OnPropertyChanged(nameof(FinishDate));
            }
        }

        public Group Group
        {
            get => _model.Group;
            set
            {
                _model.Group = value;
                OnPropertyChanged(nameof(Group));
            }
        }

        public IList<string> Members
        {
            get => _model.Members;
            set
            {
                _model.Members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        public bool CanDelete => _model.Status == "NEW";

        public bool IsCheck
        {
            get => _model.IsChecked;
            set
            {
                _model.IsChecked = value;
                //
                OnPropertyChanged(nameof(IsCheck));
            }
        }

        public Project GetProject()
        {
            return _model;
        }
    }
}