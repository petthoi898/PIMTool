using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIMTool.Services.Service.Entities
{
    [Serializable]
    public class GroupEntity : BaseEntity
    {
        public GroupEntity()
        {
            Projects = new List<ProjectEntity>();
        }
        public virtual string Name { get; set; }
        public virtual EmployeeEntity Employee { get; set; } // Column GroupLeaderID
        public virtual IList<ProjectEntity> Projects { get; set; }
    }
}