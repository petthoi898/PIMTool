using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PIMTool.Common.BusinessObjects
{
    public class Group : BusinessObjectBase
    {
        public string Name { get; set; }
        public Employee Employee { get; set; }
        public IList<Project> Projects { get; set; }
        public string GroupNameId
        {
            get
            {
                return $"ID: {Id} Name: {Name}";
            }
        }
    }

}