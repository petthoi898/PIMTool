using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Ninject;
using PIMTool.Client.DependencyInjection;
using PIMTool.Client.Presentation;
using PIMTool.Client.Presentation.ViewModel;
using PIMTool.Client.Store;
using PIMTool.Common;

namespace PIMTool.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigation = new NavigationStore();
        public static string DateFormat = "yyyy/MM/dd";
        public App()
        {
            // Initialize DI / IoC
            IoC.Initialize(
                new StandardKernel(new NinjectSettings { LoadExtensions = true }),
                new ClientBindingModule());

            // Load config for log4net
            log4net.Config.XmlConfigurator.Configure();
            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnTaskSchedulerUnobservedTaskException;
        }

        private void OnTaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
        }
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            var a = e.Exception.InnerException.InnerException.Data;
            var dictionaryException = a.Cast<System.Collections.DictionaryEntry>()
                         .Where(de => de.Key is string && de.Value is string)
                         .ToDictionary(de => (string)de.Key,
                                       de => (string)de.Value);
            if(dictionaryException == null || dictionaryException.Count == 0)
            {
                navigation.CurrentViewModel = new UnexpectedErrorViewModel(navigation, "Can't regconize this error!");

            }
            else if (dictionaryException["ExceptionType"] == "System.Data.OptimisticConcurrencyException")
                navigation.CurrentViewModel = new UnexpectedErrorViewModel(navigation, dictionaryException["ExceptionMessage"]);
            else if (dictionaryException["ExceptionType"] == "PIMTool.Services.Exceptions.ProjectNumberAlreadyExistsException")
                navigation.CurrentViewModel = new UnexpectedErrorViewModel(navigation, dictionaryException["ExceptionMessage"]);
            else if (dictionaryException["ExceptionType"] == "PIMTool.Services.Exceptions.ProjectNumberIsNotExisted")
                navigation.CurrentViewModel = new UnexpectedErrorViewModel(navigation, dictionaryException["ExceptionMessage"]);
            else if(dictionaryException["ExceptionType"] == "System.Data.ObjectNotFoundException")
                navigation.CurrentViewModel = new UnexpectedErrorViewModel(navigation, dictionaryException["ExceptionMessage"]);
            else
            {
                navigation.CurrentViewModel = new UnexpectedErrorViewModel(navigation, dictionaryException["ExceptionMessage"]);

            }
        }

        private void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            var projectsList = IoC.Get<ProjectsListViewModel>();
            navigation.CurrentViewModel = new ProjectsListViewModel(projectsList.GetProjectWebApiClient(), navigation);
            var window = new MainWindow();
            window.DataContext = new MainWindowViewModel(navigation);
            window.Show();
            base.OnStartup(e);

        }
    }
}
