using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Services.Service
{
    public class ProjectEmployeeService : IProjectEmployeeService
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;

        public ProjectEmployeeService(IUnitOfWorkProvider unitOfWorkProvider,
            IProjectEmployeeRepository projectRepository)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
            _projectEmployeeRepository = projectRepository;

        }

        public bool Contains(IList<ProjectEmployeeEntity> projectEmployees)
        {
            using (var scope = _unitOfWorkProvider.Provide())
            {
                var prjEmployees = _projectEmployeeRepository.GetAll().Select(x => x.Id).ToList();
                foreach (var element in projectEmployees)
                {
                    if (prjEmployees.Contains(element.Id)) return true;
                }
                scope.Complete();
            }

            return false;
        }

        public void Delete(IList<ProjectEmployeeEntity> projectEmployeeEntities)
        {
            using (var scope = _unitOfWorkProvider.Provide())
            {
                _projectEmployeeRepository.Delete(projectEmployeeEntities);
                scope.Complete();
            }
        }
    }
}