using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Test.Generator
{
    public class ProjectEmployeeDataGenerator
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public IProjectEmployeeRepository ProjectEmployeeRepository { get; set; }

        public ProjectEmployeeDataGenerator(IUnitOfWorkProvider unitOfWorkProvider, IProjectEmployeeRepository projectEmployeeRepository)
        {
            UnitOfWorkProvider = unitOfWorkProvider;
            ProjectEmployeeRepository = projectEmployeeRepository;
        }
        //public ProjectEntity InitProject(string projectName)
        //{
        //    return new ProjectEntity()
        //    {

        //        Name = projectName,
        //        FinishDate = null,
        //        StartDate = DateTime.Now.AddYears(-1)

        //    };
        //}

        //public EmployeeEntity InitEmployee(string name)
        //{
        //    return new EmployeeEntity()
        //    {
        //        BirthDate = DateTime.Now,
        //        FirstName = "Nguyen",
        //        LastName = "Tien",
        //        Visa = "NGUI"
        //    };
        //}

        public ProjectEmployeeEntity InitProjectEmployee(EmployeeEntity empl, ProjectEntity project)
        {
            return new ProjectEmployeeEntity()
            {
                Employee = empl,
                Project = project
            };
        }

        public void AddProjectEmployee(ProjectEmployeeEntity prjEmpl)
        {
            using (var scope = UnitOfWorkProvider.Provide())
            {
                ProjectEmployeeRepository.Add(prjEmpl);
                scope.Complete();
            }
        }

        public void Delete(ProjectEmployeeEntity prjEmpl)
        {
            using (var scope = UnitOfWorkProvider.Provide())
            {
                ProjectEmployeeRepository.Delete(prjEmpl);
                scope.Complete();
            }
        }
    }
}
