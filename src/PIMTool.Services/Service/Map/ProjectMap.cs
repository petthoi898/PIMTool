using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PIMTool.Services.Service.Map
{
    public class ProjectMap : ClassMapping<Entities.ProjectEntity>
    {
        public ProjectMap()
        {
            Table("Project");
            Lazy(false);
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.StartDate, map => map.NotNullable(true));
            Property(x => x.FinishDate, map => map.Column("EndDate"));
            Property(x => x.Name, map => map.NotNullable(true));
            Property(x => x.Customer, map => map.NotNullable(true));
            Property(x => x.ProjectNumber);
            Property(x => x.Status, map => map.NotNullable(true));
            Version(e => e.RowVersion, versionMapper =>
            {
                versionMapper.Column("Version");
                versionMapper.Generated(VersionGeneration.Never);
            });
            Bag(x => x.ProjectEmployees, map =>
            {
                map.Key(m => m.Column("ProjectID"));
                map.Inverse(true);
                map.Cascade(Cascade.All.Include(Cascade.DeleteOrphans));
                map.Fetch(CollectionFetchMode.Subselect);
                map.Lazy(CollectionLazy.NoLazy);
            }, mapp => mapp.OneToMany());
            ManyToOne(x => x.Group, map =>
            {
                map.Column("GroupID");
                map.Cascade(Cascade.None);
                //map.NotNullable(true);
                map.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}