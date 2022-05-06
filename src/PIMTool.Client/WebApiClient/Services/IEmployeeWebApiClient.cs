using System.Collections.Generic;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.WebApiClient.Services
{
    public interface IEmployeeWebApiClient 
    {
        IList<Employee> GetAllEmployees();
    }
}
