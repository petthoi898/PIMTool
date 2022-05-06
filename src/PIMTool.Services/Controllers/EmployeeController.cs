using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PIMTool.Common;
using PIMTool.Common.BusinessObjects;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Controllers
{
    [RoutePrefix(RouteConstants.EmployeeApi)]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [Route(RouteConstants.GetAllEmployees)]
        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            var employees = _mapper.Map<IList<EmployeeEntity>, IList<Employee>>(_employeeService.GetAll());
            return Ok(employees);
        }
    }
}