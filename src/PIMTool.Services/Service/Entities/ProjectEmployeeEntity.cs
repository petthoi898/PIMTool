using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIMTool.Services.Service.Entities
{
    [Serializable]
    public class ProjectEmployeeEntity : BaseEntity
    {
        public virtual ProjectEntity Project { get; set; } // ProjectID
        public virtual EmployeeEntity Employee { get; set; } // EmployeeID
    }
}