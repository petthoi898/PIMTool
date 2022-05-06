using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Service.Map
{
    public class TaskMap : ClassMapping<TaskEntity>
    {

        public TaskMap()
        {
            Table("Task");
            
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.Name);
            Property(x => x.DeadlineDate);
            Version(e => e.RowVersion, versionMapper => versionMapper.Generated(VersionGeneration.Never));
            ManyToOne(x => x.Project, map =>
            {
                map.Column("PROJECTID"); 
                map.Cascade(Cascade.All);
                map.NotNullable(true);
            });

        }
    }
}