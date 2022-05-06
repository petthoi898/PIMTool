using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Service.Map
{
    public class ProjectEmployeeMap : ClassMapping<ProjectEmployeeEntity>
    {
        public ProjectEmployeeMap()
        {
            Table("ProjectEmployee");
            Id(x => x.Id, version => version.Generator(Generators.Identity));

            ManyToOne(x => x.Employee, map =>
            {
                map.Column("EmployeeID");
                map.Cascade(Cascade.None);
                map.Lazy(LazyRelation.NoLazy);
            });
            ManyToOne(x => x.Project, map =>
            {
                map.Column("ProjectID");
                map.Cascade(Cascade.None);
                map.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}