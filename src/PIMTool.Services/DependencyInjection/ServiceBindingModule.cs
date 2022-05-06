
using AutoMapper;
using log4net;
using NHibernate;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using PIMTool.Services.Constants;
using PIMTool.Services.Profile;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Generic;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Pattern.SessionFactory;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Services.DependencyInjection
{
    public class ServiceBindingModule : NinjectModule
    {
        public override void Load()
        {
            ConfigureLog4Net();
            ConfigureNHibernate();
            BindServices();
            ConfigureAutoMapper();
        }

        private void ConfigureAutoMapper()
        {
            Kernel.Bind<IMapper>()
                .ToMethod(context =>
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<MappingProfile>();
                        // tell automapper to use ninject when creating value converters and resolvers
                        cfg.ConstructServicesUsing(t => Kernel.Get(t));
                    });
                    return config.CreateMapper();
                }).InSingletonScope();
        }

        private void ConfigureLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();

            var logger = LogManager.GetLogger(WebConstants.WEB_SERVER_TRACE);
            Bind<ILog>().ToConstant(logger);
        }

        private void ConfigureNHibernate()
        {
            Bind<ISessionFactory>().ToProvider<PIMToolSessionFactoryProvider<PIMToolSessionFactory>>()
                .InSingletonScope();
            Bind<IUnitOfWorkProvider>()
                .To<UnitOfWorkProvider>()
                .WithConstructorArgument(WebConstants.SessionFactory, x => x.Kernel.Get<ISessionFactory>());
            Bind<ISession>().ToMethod(x => x.Kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();
        }

        private void BindServices()
        {
            Bind<IProjectService>().To<ProjectService>().InSingletonScope();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IGroupService>().To<GroupService>().InSingletonScope();
            Bind<IGroupRepository>().To<GroupRepository>();
            Bind<IEmployeeService>().To<EmployeeService>().InSingletonScope();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
            Bind<IProjectEmployeeService>().To<ProjectEmployeeService>().InSingletonScope();
            Bind<IProjectEmployeeRepository>().To<ProjectEmployeeRepository>();
        }
    }
}