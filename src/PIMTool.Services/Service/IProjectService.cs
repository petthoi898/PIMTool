using System.Collections.Generic;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Service
{
    public interface IProjectService
    {
        void DeleteProject(List<ProjectEntity> projects);
        IList<Entities.ProjectEntity> GetAll();
        Entities.ProjectEntity GetById(int projectId);
        void AddNewProject(Entities.ProjectEntity entity, IList<ProjectEmployeeEntity> projectEmployeeEntities);
        void DeleteProject(ProjectEntity project);
        IList<ProjectEntity> Search(Dictionary<string, string> search);
        void Update(ProjectEntity entity);
        ProjectEntity GetProjectByProjectNumber(int projectNumber);
    }
}