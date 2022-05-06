using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Common.BusinessObjects
{
    public class Member : BusinessObjectBase
    {
        public virtual string EmployeeVisa { set; get; }
        public virtual string EmployeeFirstName { get; set; }
        public virtual string EmployeeLastName { get; set; }
        public virtual DateTime EmployeeBirthDate { get; set; }
    }
}
