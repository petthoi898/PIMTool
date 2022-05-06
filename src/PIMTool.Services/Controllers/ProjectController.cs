using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using AutoMapper;
using PIMTool.Common;
using PIMTool.Common.BusinessObjects;
using PIMTool.Services.Exceptions;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Entities;


namespace PIMTool.Services.Controllers
{
    [RoutePrefix(RouteConstants.ProjectApi)]
    public class ProjectController : ApiController
    {

        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;

        private readonly IMapper _mapper;
        public ProjectController(
            IProjectService projectService, IEmployeeService employeeService, IMapper mapper)
        {
            _mapper = mapper;
            _projectService = projectService;
            _employeeService = employeeService;
        }

        [Route(RouteConstants.GetAllProjects)]
        [HttpGet]
        public IHttpActionResult GetProjects()
        {
            //[TODO] call real service
            var projectsEntity = _projectService.GetAll();
            var listProject = _mapper.Map<IList<ProjectEntity>, IList<Project>>(projectsEntity);
            return Ok(listProject);
        }

        [Route(RouteConstants.GetProjectServer)]

        [HttpGet]
        public IHttpActionResult GetProject(int projectId)
        {
            //[TODO] call real service

            var projectEntity = _projectService.GetById(projectId);
            if (projectEntity == null)
                throw new ObjectNotFoundException("Do not existed this Project!");
            var projectDto = _mapper.Map<Project>(projectEntity);
            return Ok(projectDto);
        }

        [Route(RouteConstants.GetProjectByProjectNumberServer)]
        [HttpGet]
        public IHttpActionResult GetProjectByProjectNumber(int projectNumber)
        {
            var projectEntity = _projectService.GetProjectByProjectNumber(projectNumber);
            if (projectEntity == null)
                throw new ObjectNotFoundException("Do not existed this project! Maybe be deleted before.");
            var projectDto = _mapper.Map<Project>(projectEntity);
            return Ok(projectDto);
        }
        [Route(RouteConstants.AddNewProject)]
        [HttpPost]
        public IHttpActionResult AddNewProject(Project project)
        {
            var projectEntity = _mapper.Map<ProjectEntity>(project);
            // Clear old ProjectEmployee old
            IList<ProjectEmployeeEntity> projectEmployeeDis = projectEntity.ProjectEmployees;
            projectEntity.ProjectEmployees = MembersToProjectEmployeeEntity(project.Members, projectEntity);
            _projectService.AddNewProject(projectEntity, projectEmployeeDis);
            return Ok(project);
        }

        [Route(RouteConstants.DeleteProjectServer)]
        [HttpPost]
        public IHttpActionResult DeleteProject(Project project)
        {
            var projectEntity = _projectService.GetById(project.Id);
            if (projectEntity == null)
            {
                throw new ObjectNotFoundException(string.Format("Project Number {0} is not existed in System!"));
            }
            if (projectEntity.RowVersion != project.RowVersion)
                throw new OptimisticConcurrencyException("This project updated before delete!");
            _projectService.DeleteProject(projectEntity);
            return Ok();
        }
        [Route(RouteConstants.DeleteMultiProjectsServer)]
        [HttpPost]
        public IHttpActionResult DeleteMultiProjects(IList<Project> projects)
        {
            var listProjectEntity = new List<ProjectEntity>();
            foreach (var project in projects)
            {
                listProjectEntity.Add(_projectService.GetById(project.Id));
            }
            _projectService.DeleteProject(listProjectEntity);

            return Ok();
        }
        // Search
        [Route(RouteConstants.SearchServer)]
        [HttpPost]
        public IHttpActionResult SearchProjects(Dictionary<string, string> search)
        {
            var projectsEntity = _projectService.Search(search);
            var projectsDto = _mapper.Map<IList<ProjectEntity>, IList<Project>>(projectsEntity);
            return Ok(projectsDto);
        }

        private IList<ProjectEmployeeEntity> MembersToProjectEmployeeEntity(IList<string> members, ProjectEntity project)
        {
            if (members.Any(x => string.IsNullOrEmpty(x))) return new List<ProjectEmployeeEntity>();
            IList<ProjectEmployeeEntity> result = new List<ProjectEmployeeEntity>();
            var employees = _employeeService.GetAll();
            foreach (var visa in members)
            {
                result.Add(new ProjectEmployeeEntity()
                {
                    Employee = employees.First(x => x.Visa == visa),
                    Project = project
                });
            }
            return result;
        }

    }
}
