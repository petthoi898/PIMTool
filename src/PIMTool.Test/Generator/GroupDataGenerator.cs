using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Generic;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Test.Generator
{
    public class GroupDataGenerator
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public IGroupRepository GroupRepository { get; set; }

        public GroupDataGenerator(IUnitOfWorkProvider unitOfWorkProvider, IGroupRepository groupRepository)
        {
            UnitOfWorkProvider = unitOfWorkProvider;
            GroupRepository = groupRepository;
        }
        public GroupEntity InitGroup(string name, EmployeeEntity employee)
        {
            return new GroupEntity()
            {
                Name = name,
                Employee = employee
            };

        }
        public void DeleteGroup(GroupEntity group)
        {
            using (var scope = UnitOfWorkProvider.Provide())
            {
                var groupDb = GroupRepository.GetById(group.Id);
                GroupRepository.Delete(groupDb);
                scope.Complete();
            }
        }
        public void AddGroup(GroupEntity group)
        {
            using (var scope = UnitOfWorkProvider.Provide())
            {
                GroupRepository.Add(group);
                scope.Complete();
            }
        }
        public void AddProject(GroupEntity group, ProjectEntity project)
        {
            group.Projects.Add(project);
            project.Group = group;
        }
        public ProjectEntity InitProject(string projectName)
        {
            return new ProjectEntity()
            {

                Name = projectName,
                FinishDate = null,
                StartDate = DateTime.Now.AddYears(-1),
                ProjectNumber = 1,
                Customer = "ELCA",
                Status = "INP"
            };
        }
    }
}
