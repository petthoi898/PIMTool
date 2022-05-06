using System.Collections.Generic;
using PIMTool.Common.BusinessObjects;

namespace PIMTool.Client.WebApiClient.Services
{
    public interface IGroupWebApiClient
    {
        IList<Group> GetAllGroups();
    }
}
