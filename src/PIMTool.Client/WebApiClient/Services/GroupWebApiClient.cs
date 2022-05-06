using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMTool.Common;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.WebApiClient.Services
{
    public class GroupWebApiClient : WebApiClientBase, IGroupWebApiClient
    {
        public GroupWebApiClient(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }
        public override string RoutePrefix => RouteConstants.GroupApi;
        public IList<Group> GetAllGroups()
        {
            return Task.Run(() => Get<IList<Group>>(RouteConstants.GetAllGroups)).Result;

        }
    }
}
