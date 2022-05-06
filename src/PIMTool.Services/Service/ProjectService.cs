using System;
using System.Collections.Generic;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Repository;
using System.Data;
using System.Linq;
using PIMTool.Services.Exceptions;

namespace PIMTool.Services.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectEmployeeService _projectEmployeeService;

        public ProjectService(IUnitOfWorkProvider unitOfWorkProvider,
            IProjectRepository projectRepository, IProjectEmployeeService projectEmployeeService)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
            _projectRepository = projectRepository;
            _projectEmployeeService = projectEmployeeService;
        }

        public void AddNewProject(ProjectEntity entity, IList<ProjectEmployeeEntity> projectEmployeeEntities)
        {
            using (var scope = _unitOfWorkProvider.Provide())
            {
                if (entity.Id == 0)
                {
                    var check = _projectRepository.GetAll().FirstOrDefault(x => x.ProjectNumber == entity.ProjectNumber);
                    if (check != null)
                        throw new ProjectNumberAlreadyExistsException(entity.ProjectNumber);
                    _projectRepository.SaveOrUpdate(entity);
                }
                else
                {
                    ProjectEntity projectDb;
                    using (var scopeNew = _unitOfWorkProvider.Provide(UnitOfWorkScopeOption.RequiresNew))
                    {
                        projectDb = GetById(entity.Id);
                        scopeNew.Complete();
                    }
                    if (projectDb == null)
                        throw new OptimisticConcurrencyException("The project is deleted before!");
                    if (entity.RowVersion != projectDb.RowVersion)
                        throw new OptimisticConcurrencyException("Failed because of concurrency update!");
                    DisableProjectEmployee(projectEmployeeEntities);
                    _projectRepository.SaveOrUpdate(entity);
                }
                scope.Complete();
            }
        }

        public void DeleteProject(ProjectEntity project)
        {
            using (var scope = _unitOfWorkProvider.Provide())
            {
                _projectRepository.Delete(project);
                scope.Complete();
            }
        }
        public void DeleteProject(List<ProjectEntity> project)
        {
            using (var scope = _unitOfWorkProvider.Provide())
            {
                _projectRepository.Delete(project);
                scope.Complete();
            }
        }

        public IList<Entities.ProjectEntity> GetAll()
        {
            IList<Entities.ProjectEntity> result;
            using (var scope = _unitOfWorkProvider.Provide())
            {
                result = _projectRepository.GetAll();
                scope.Complete();
            }
            return result;
        }

        public Entities.ProjectEntity GetById(int projectId)
        {
            return _unitOfWorkProvider.PerformActionInUnitOfWork(() => _projectRepository.GetById(projectId));
        }
        public IList<ProjectEntity> Search(Dictionary<string, string> search)
        {
            IList<ProjectEntity> result;

            using (var scope = _unitOfWorkProvider.Provide())
            {
                result = _projectRepository.Search(search);
                scope.Complete();
            }

            return result;
        }
        public void Update(ProjectEntity entity)
        {
            using (var scope = _unitOfWorkProvider.Provide())
            {
                _projectRepository.SaveOrUpdate(entity);
                scope.Complete();
            }
        }
        public ProjectEntity GetProjectByProjectNumber(int projectNumber)
        {
            ProjectEntity result;
            using (var scope = _unitOfWorkProvider.Provide())
            {
                result = _projectRepository.GetProjectByProjectNumber(projectNumber);
            }

            return result;
        }
        private void DisableProjectEmployee(IList<ProjectEmployeeEntity> projectEmployeeEntities)
        {
            using (var scope = _unitOfWorkProvider.Provide())
            {
                _projectEmployeeService.Delete(projectEmployeeEntities);
                scope.Complete();
            }
        }
    }
}