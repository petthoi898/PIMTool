using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIMTool.Services.Service.Entities
{
    [Serializable]
    public class EmployeeEntity : BaseEntity
    {
        public EmployeeEntity()
        {
            ProjectEmployee = new List<ProjectEmployeeEntity>();
        }
        public virtual string Visa { set; get; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual IList<ProjectEmployeeEntity> ProjectEmployee { get; set; }
    }
}