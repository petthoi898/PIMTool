using System;
using System.Collections.Generic;

namespace PIMTool.Common.BusinessObjects
{
    public class Project : BusinessObjectBase
    {
        public Project()
        {
            ProjectEmployees = new List<ProjectEmployee>();
            Members = new List<string>();
        }
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Status { get; set; }
        //public int GroupId { get; set; }
        public IList<string> Members { get; set; }
        public string Customer { get; set; }
        public int ProjectNumber { get; set; }
        public bool IsChecked { get; set; }
        public bool IsShowButton => Status == "NEW";
        public IList<ProjectEmployee> ProjectEmployees { get; set; }
        public Group Group { get; set; }
    }
}