using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using PIMTool.Client.Command;
using PIMTool.Client.Store;

namespace PIMTool.Client.Presentation.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        //private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get => _navigationStore.CurrentViewModel;
            set
            {
                _navigationStore.CurrentViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
                OnPropertyChanged(nameof(IsUnexpectedError));
            }
        }

        public PointCollection LineHorizontal { get; set; }
        public PointCollection LineVertical { get; set; }
        public ICommand NavigateProjectsListCommand { get; set; }
        public ICommand NavigateNewProjectCommand { get; set; }

        public bool IsUnexpectedError =>
            !(_navigationStore.CurrentViewModel.GetType().Name == typeof(UnexpectedErrorViewModel).Name);
        public MainWindowViewModel(NavigationStore navigation)
        {
            _navigationStore = navigation;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            //
            NavigateProjectsListCommand = new NavigateProjectsListCommand(_navigationStore);
            NavigateNewProjectCommand = new NavigateNewProjectCommand(_navigationStore);
            LineHorizontal = new PointCollection()
            {
                new Point(0, 700),
                new Point(1200, 700)
            };
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
            OnPropertyChanged(nameof(IsUnexpectedError));
        }
    }
}