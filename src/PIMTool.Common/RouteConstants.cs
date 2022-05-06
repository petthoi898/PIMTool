namespace PIMTool.Common
{
    public static class RouteConstants
    {
        // Project Route API
        public const string ProjectApi = "api/project";
        public const string GroupApi = "api/group";
        public const string EmployeeApi = "api/employee";
        public const string GetAllProjects = "GetAll";
        public const string GetAllGroups = "GetAll";
        public const string GetAllEmployees = "GetAll";
        public const string GetProjectClient = "GetProject/{0}";
        public const string DeleteProjectClient = "DeleteProject/{0}";
        public const string GetProjectServer = "GetProject/{projectId}";
        public const string DeleteProjectServer = "DeleteProject/{projectId}";
        public const string AddNewProject = "PostProject";
        public const string GetProjectsBySearchClient = "SearchProject/{0}/{1}";
        public const string GetProjectsBySearchServer = "SearchProject/{field}/{status}";
        public const string SearchProjectByStatusClient = "SearchProjectByStatus/{0}";
        public const string SearchProjectByStatusServer = "SearchProjectByStatus/{status}";
        public const string SearchProjectByFieldClient = "SearchProjectByField/{0}";
        public const string SearchProjectByFieldServer = "SearchProjectByField/{field}";
        public const string GetProjectByProjectNumberClient = "GetProjectNumber/{0}";
        public const string GetProjectByProjectNumberServer = "GetProjectNumber/{projectNumber}";
        public const string UpdateProject = "UpdateProject";
        public const string DeleteMultiProjectsClient = "DeleteMultiProjects/{0}";
        public const string DeleteMultiProjectsServer = "DeleteMultiProjects/{projectId}";
        public const string SearchClient = "SearchProject/{0}";
        public const string SearchServer = "SearchProject/{search}";

    }
}