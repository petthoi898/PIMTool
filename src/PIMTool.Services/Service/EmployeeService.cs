using PIMTool.Services.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Services.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IUnitOfWorkProvider unitOfWorkProvider, IEmployeeRepository employeeRepository)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
            _employeeRepository = employeeRepository;
        }

        public IList<Entities.EmployeeEntity> GetAll()
        {
            IList<Entities.EmployeeEntity> result;
            using (var scope = _unitOfWorkProvider.Provide())
            {
                result = _employeeRepository.GetAll();
                scope.Complete();
            }
            return result;
        }

        public Entities.EmployeeEntity GetById(int projectId)
        {
            return _unitOfWorkProvider.PerformActionInUnitOfWork<Entities.EmployeeEntity>(() => _employeeRepository.GetById(projectId));
        }
    }
}