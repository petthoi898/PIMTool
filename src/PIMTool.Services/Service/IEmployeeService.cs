using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Services.Service
{
    public interface IEmployeeService
    {
        IList<Entities.EmployeeEntity> GetAll();
        Entities.EmployeeEntity GetById(int employeeId);
    }
}