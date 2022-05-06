using PIMTool.Services.Service;
using PIMTool.Services.Service.Generic;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Test
{
    public class ProjectRepositoryTestModule : BaseRepositoryTestModule
    {
        public override void Load()
        {
            LoadModule();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<IGroupRepository>().To<GroupRepository>();
            //Bind<IGroupLeaderService>().To<GroupLeaderService>();
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
            Bind<IProjectEmployeeRepository>().To<ProjectEmployeeRepository>();
            Bind<IProjectEmployeeService>().To<ProjectEmployeeService>();
        }

    }


}
