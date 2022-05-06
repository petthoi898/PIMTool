using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using NUnit.Framework;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Generic;
using PIMTool.Services.Service.Repository;
using PIMTool.Test.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PIMTool.Test
{
    [TestClass]
    public class GroupServiceTest : BaseTest
    {
        protected static readonly ILog log = LogManager.GetLogger("PIMToolApp");
        private GroupDataGenerator _generator;

        protected override INinjectModule GetServiceBindingModule()
            => new ProjectRepositoryTestModule();

        public IGroupRepository GroupRepository => Kernel.Get<IGroupRepository>();
        public IGroupService GroupService => Kernel.Get<IGroupService>();
        public IEmployeeService EmployeeService => Kernel.Get<IEmployeeService>();

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            Setup();
            _generator = new GroupDataGenerator(UnitOfWorkProvider, GroupRepository);
        }
        [Test]
        public void TestNumberListOfGroup()
        {
            GroupEntity group = new GroupEntity();
            try
            {
                group = _generator.InitGroup("KSTA 1", EmployeeService.GetAll().First());
                _generator.AddProject(group, _generator.InitProject("Project Test 1"));
                _generator.AddProject(group, _generator.InitProject("Project Test 2"));
                _generator.AddGroup(group);
                IList<GroupEntity> listDbGroup;
                using (var scope = UnitOfWorkProvider.Provide())
                {
                    listDbGroup = GroupService.GetAll();
                    scope.Complete();
                }
                Assert.IsTrue(group.Name == "KSTA 1");
            }

            finally
            {
                if (group.Id > 0)
                {
                    _generator.DeleteGroup(group);
                }
            }
        }
        //[Test]
        //public void TestGetById()
        //{
        //    GroupEntity group = new GroupEntity();
        //    GroupEntity group1 = new GroupEntity();
        //    try
        //    {
        //        group = _generator.InitGroup("KSTA");
        //        _generator.AddProject(group, _generator.InitProject("Project Test 1"));
        //        group1 = _generator.InitGroup("KSTA1");
        //        _generator.AddProject(group, _generator.InitProject("Project Test 2"));
        //        _generator.AddGroup(group1);
        //        _generator.AddGroup(group);
        //        IList<GroupEntity> listDbGroup;
        //        using (var scope = UnitOfWorkProvider.Provide())
        //        {
        //            listDbGroup = GroupService.GetById();
        //            scope.Complete();
        //        }
        //        Assert.IsTrue(group.Name == "KSTA");
        //    }

        //    finally
        //    {
        //        if (group.Id > 0)
        //        {
        //            _generator.DeleteGroup(group);
        //            _generator.DeleteGroup(group1);
        //        }
        //    }
        //}
    }
}
