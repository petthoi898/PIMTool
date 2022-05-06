using Ninject;
using Ninject.Modules;
using NUnit.Framework;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Test
{
    //public class ProjectRepositoryTest : BaseTest
    //{
    //    private ProjectDataGenerator _generator;

    //    protected override INinjectModule GetServiceBindingModule()
    //        => new ProjectRepositoryTestModule();

    //    public IProjectRepository ProjectRepository => Kernel.Get<IProjectRepository>();

    //    [TestFixtureSetUp]
    //    public void TestFixtureSetup()
    //    {
    //        Setup();
    //        _generator = new ProjectDataGenerator(UnitOfWorkProvider, ProjectRepository);
    //    }

    //    [Test]
    //    public void TestAddProject()
    //    {
    //        ProjectEntity project = new ProjectEntity();
    //        try
    //        {
    //            project = _generator.InitProject("Test");
    //            project.Id = 3;
    //            _generator.AddProject(project);
    //            var status = _generator.GetStatusByProjectName("Test");

    //            Assert.IsTrue(project.Id > 0);

    //        }
    //        finally
    //        {
    //            if (project.Id > 0)
    //            {
    //                _generator.DeleteProject(project);
    //            }
    //        }

    //    }

    //    [Test]
    //    public void TestAddMultiProject()
    //    {
    //        ProjectEntity project1 = new ProjectEntity();
    //        ProjectEntity project2 = new ProjectEntity();
    //        try
    //        {
    //            project1 = _generator.InitProject("Project1_Multi");
    //            project2 = _generator.InitProject("Project2_Multi");
    //            _generator.AddProject(project1);
    //            _generator.AddProject(project2);
    //            Assert.IsTrue(project1.Id > 0);
    //            Assert.IsTrue(project2.Id > 0);
    //        }
    //        finally
    //        {
    //            if (project1.Id > 0)
    //            {
    //                _generator.DeleteProject(project1);
    //            }
    //            if (project2.Id > 0)
    //            {
    //                _generator.DeleteProject(project2);
    //            }
    //        }
    //    }

    //    [Test]
    //    public void TestQueryProject()
    //    {
    //        ProjectEntity project = new ProjectEntity();
    //        try
    //        {
    //            project = _generator.InitProject("GetAttribute");
    //            _generator.AddProject(project);
    //            var projectSearch = _generator.GetProjectByName("GetAttribute");
    //            Assert.AreNotEqual(projectSearch, null);
    //        }
    //        finally
    //        {
    //            if (project.Id > 0)
    //            {
    //                _generator.DeleteProject(project);
    //            }
    //        }
    //    }
    //}
}
