using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PIMTool.Services.Service.Entities
{
    [Serializable]
    public class ProjectEntity : BaseEntity
    {
        public ProjectEntity()
        {
            ProjectEmployees = new List<ProjectEmployeeEntity>();
        }

        [Required, StringLength(100), Display(Name = "Project Name")]
        public virtual string Name
        {
            get;
            set;
        }

        [Required, Display(Name = "Start Date")]
        public virtual DateTime StartDate
        {
            get;
            set;
        }

        [Display(Name = "Finish Date")]
        public virtual DateTime? FinishDate
        {
            get;
            set;
        }
        public virtual int ProjectNumber { get; set; }
        public virtual string Customer { get; set; }
        public virtual string Status { get; set; }
        public virtual GroupEntity Group { get; set; } // Column GroupID
        public virtual IList<ProjectEmployeeEntity> ProjectEmployees { get; set; }

    }
}