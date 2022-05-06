using System.Collections.Generic;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.WebApiClient.Services
{
    public interface IProjectWebApiClient
    {
        IList<Project> GetAllProjects();
        Project GetProject(int projectId);
        Project AddNewProject(Project newProject);
        Project DeleteProject(Project project);
        Project DeleteMultiProjects(IList<Project> projects);
        IList<Project> SearchProjects(Dictionary<string, string> search);
        Project GetProjectByProjectNumber(int projectNumber);
        Project UpdateProject(Project project);
    }
}