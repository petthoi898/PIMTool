using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PIMTool.Services.Service.Entities;

namespace PIMTool.Services.Service.Map
{
    public class EmployeeMap : ClassMapping<EmployeeEntity>
    {
        public EmployeeMap()
        {
            Table("Employee");
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Version(e => e.RowVersion, versionMapper =>
            {
                versionMapper.Column("Version");
                versionMapper.Generated(VersionGeneration.Never);
            });
            Property(x => x.Visa, map =>
            {
                map.Column("Visa");
                map.NotNullable(true);
            });
            Property(x => x.BirthDate, map => map.NotNullable(true));
            Property(x => x.FirstName, map => map.NotNullable(true));
            Property(x => x.LastName, map => map.NotNullable(true));
            Bag(x => x.ProjectEmployee, map =>
            {
                map.Key(m => m.Column("EmployeeID"));
                map.Inverse(true);
                map.Cascade(Cascade.All);
                map.Lazy(CollectionLazy.NoLazy);
            }, mapp => mapp.OneToMany());

        }
    }
}