using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Services.Service
{
    public interface IGroupService
    {
        IList<Entities.GroupEntity> GetAll();
        Entities.GroupEntity GetById(int projectId);

    }
}