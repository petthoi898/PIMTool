using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Test.Generator
{
    public class EmployeeDataGenerator
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }

        public EmployeeDataGenerator(IUnitOfWorkProvider unitOfWorkProvide, IEmployeeRepository employeeRepository)
        {
            UnitOfWorkProvider = unitOfWorkProvide;
            EmployeeRepository = employeeRepository;
        }

        public EmployeeEntity InitEmployee(string name)
        {
            return new EmployeeEntity()
            {
                BirthDate = DateTime.Now,
                FirstName = name,
                LastName = name,
                Visa = name
            };
        }

        public void AddEmployee(EmployeeEntity employee)
        {
            using (var scope = UnitOfWorkProvider.Provide())
            {
                EmployeeRepository.Add(employee);
                scope.Complete();
            }
        }

        public void Delete(EmployeeEntity employee)
        {
            using (var scope = UnitOfWorkProvider.Provide())
            {
                EmployeeRepository.Delete(employee);
                scope.Complete();
            }
        }
    }
}
