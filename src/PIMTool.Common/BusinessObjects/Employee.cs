using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Common.BusinessObjects
{
    public class Employee : BusinessObjectBase
    {

        public string Visa { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IList<ProjectEmployee> ProjectEmployee { get; set; }
    }
}