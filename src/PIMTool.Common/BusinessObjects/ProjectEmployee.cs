using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Common.BusinessObjects
{
    public class ProjectEmployee : BusinessObjectBase
    {
        public virtual Project Project { get; set; } // ProjectID
        public virtual Employee Employee { get; set; } // EmployeeID
    }
}
