using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIMTool.Common;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.WebApiClient.Services
{
    public class EmployeeWebApiClient : WebApiClientBase, IEmployeeWebApiClient
    {
        public EmployeeWebApiClient(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }
        public override string RoutePrefix => RouteConstants.EmployeeApi;

        public IList<Employee> GetAllEmployees()
        {
            return Task.Run(() => Get<IList<Employee>>(RouteConstants.GetAllEmployees)).Result;

        }
    }
}
