using System.Collections.Generic;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Generic;

namespace PIMTool.Services.Service.Repository
{
    public interface IProjectRepository : IBaseRepository<Entities.ProjectEntity>
    {
        IList<ProjectEntity> Search(Dictionary<string, string> search);
        ProjectEntity GetProjectByProjectNumber(int projectNumber);
    }
}