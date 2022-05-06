using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Service.Map
{
    public class GroupMap : ClassMapping<GroupEntity>
    {

        public GroupMap()
        {
            Table("Group");
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.Name, map => map.Column("Name"));
            Version(e => e.RowVersion, versionMapper =>
            {
                versionMapper.Column("Version");
                versionMapper.Generated(VersionGeneration.Never);
            });
            Bag(x => x.Projects, map =>
            {
                map.Key(cmap => cmap.Column("GroupID"));
                map.Inverse(true);
                map.Fetch(CollectionFetchMode.Subselect);
                map.Cascade(Cascade.All);
                map.Lazy(CollectionLazy.NoLazy);
            }, mapp => mapp.OneToMany());
            ManyToOne(i => i.Employee, map => // groupLeader
            {
                map.Column("GroupLeaderID");
                map.Cascade(Cascade.None);
                map.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}