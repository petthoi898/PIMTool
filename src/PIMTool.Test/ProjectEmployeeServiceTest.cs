using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using NUnit.Framework;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Repository;
using PIMTool.Test.Generator;
using PIMTool.Services.Service.Generic;
using PIMTool.Test.Generator;

namespace PIMTool.Test
{
    public class ProjectEmployeeServiceTest : BaseTest
    {
        protected static readonly ILog log = LogManager.GetLogger("PIMToolApp");
        private ProjectEmployeeDataGenerator _generator;
        private ProjectDataGenerator _generatorProject;
        private EmployeeDataGenerator _generatorEmployee;
        private GroupDataGenerator _generatorGroup;
        protected override INinjectModule GetServiceBindingModule()
            => new ProjectRepositoryTestModule();
        public IProjectEmployeeService ProjectEmployeeService => Kernel.Get<IProjectEmployeeService>();

        public IProjectRepository ProjectRepository => Kernel.Get<IProjectRepository>();
        public IProjectEmployeeRepository ProjectEmployeeRepository => Kernel.Get<IProjectEmployeeRepository>();
        public IEmployeeRepository EmployeeRepository => Kernel.Get<IEmployeeRepository>();
        public IGroupRepository GroupRepository => Kernel.Get<IGroupRepository>();

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            Setup();
            _generator = new ProjectEmployeeDataGenerator(UnitOfWorkProvider, ProjectEmployeeRepository);
            _generatorProject = new ProjectDataGenerator(UnitOfWorkProvider, ProjectRepository);
            _generatorEmployee = new EmployeeDataGenerator(UnitOfWorkProvider, EmployeeRepository);
            _generatorGroup = new GroupDataGenerator(UnitOfWorkProvider, GroupRepository);
        }

        [Test]
        public void TestContains()
        {
            ProjectEmployeeEntity prjEmpl = new ProjectEmployeeEntity();
            try
            {
                var employee = _generatorEmployee.InitEmployee("Tien");
                _generatorEmployee.AddEmployee(employee);
                var group = _generatorGroup.InitGroup("TEST GROUP", employee);
                _generatorGroup.AddGroup(group);
                var project = _generatorProject.InitProject("HDQA", group);
                _generatorProject.AddProject(project);
                _generatorEmployee.AddEmployee(employee);
                prjEmpl = _generator.InitProjectEmployee(employee, project);
                _generator.AddProjectEmployee(prjEmpl);
                IList<ProjectEmployeeEntity> listPrjEmplDb = new List<ProjectEmployeeEntity>();
                listPrjEmplDb.Add(prjEmpl);
                bool check;
                using (var scope = UnitOfWorkProvider.Provide())
                {
                    check = ProjectEmployeeService.Contains(listPrjEmplDb);
                }
                Assert.IsTrue(check);
            }
            finally
            {
                if (prjEmpl.Id > 0)
                {
                    _generator.Delete(prjEmpl);
                }
            }
        }
       
        
    }
}
