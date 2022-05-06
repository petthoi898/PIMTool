using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Service
{
    public interface IProjectEmployeeService
    {
        void Delete(IList<ProjectEmployeeEntity> projectEmployeeEntities);
        bool Contains(IList<ProjectEmployeeEntity> projectEmployee);
    }
}
