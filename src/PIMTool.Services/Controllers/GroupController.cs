using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using AutoMapper;
using PIMTool.Common;
using PIMTool.Common.BusinessObjects;
using PIMTool.Services.Service;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Controllers
{
    [RoutePrefix(RouteConstants.GroupApi)]
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public GroupController(
            IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [Route(RouteConstants.GetAllGroups)]
        [HttpGet]
        public IHttpActionResult GetGroups()
        {
            //[TODO] call real service
            var groups = _groupService.GetAll();
            var groupsDto = _mapper.Map<IList<GroupEntity>, IList<Common.BusinessObjects.Group>>(groups);
            
            return Ok(groupsDto);
        }
    }
}