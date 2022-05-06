using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using PIMTool.Common;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.WebApiClient.Services
{
    public class ProjectWebApiClient : WebApiClientBase, IProjectWebApiClient
    {
        public ProjectWebApiClient(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }
        public override string RoutePrefix => RouteConstants.ProjectApi;

        public Project AddNewProject(Project newProject)
        {
            return Task.Run(() => Post<Project>(RouteConstants.AddNewProject, newProject)).Result;
        }
        public Project UpdateProject(Project project)
        {
            return Task.Run(() => Post<Project>(RouteConstants.UpdateProject, project)).Result;
        }
        public Project DeleteProject(Project project)
        {
            return Task.Run(() => Post<Project>(RouteConstants.DeleteProjectClient, project)).Result;
        }
        public Project DeleteMultiProjects(IList<Project> project)
        {
            return Task.Run(() => Post<Project>(RouteConstants.DeleteMultiProjectsClient, project)).Result;
        }
        public IList<Project> GetAllProjects()
        {
            return Task.Run(() => Get<IList<Project>>(RouteConstants.GetAllProjects)).Result;
        }

        public Project GetProject(int projectId)
        {
            return Task.Run(() => Get<Project>(string.Format(RouteConstants.GetProjectClient, projectId))).Result;
        }
        public Project GetProjectByProjectNumber(int projectNumber)
        {
            return Task.Run(() =>
                Get<Project>(string.Format(RouteConstants.GetProjectByProjectNumberClient, projectNumber))).Result;
        }
        public IList<Project> SearchProjects(Dictionary<string, string> search)
        {
            return Task.Run(() => Post<IList<Project>>(RouteConstants.SearchClient, search)).Result;
        }
    }
}