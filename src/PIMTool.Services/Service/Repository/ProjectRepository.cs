using System;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Generic;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using NHibernate;

namespace PIMTool.Services.Service.Repository
{
    public class ProjectRepository : BaseRepository<Entities.ProjectEntity>, IProjectRepository
    {
        public ProjectEntity GetProjectByProjectNumber(int projectNumber)
        {
            return GetAll().FirstOrDefault(x => x.ProjectNumber == projectNumber);
        }
        public IList<ProjectEntity> Search(Dictionary<string, string> search)
        {
            var like = "%" + search["field"] + "%";
            var status = "%" + search["status"] + "%";
            var result = Session.QueryOver<ProjectEntity>().Where(
                (Restrictions.On<ProjectEntity>(x => x.Name).IsLike(like)
                || Restrictions.On<ProjectEntity>(x => x.Customer).IsLike(like)
                || Expression.Like(Projections.Cast(NHibernateUtil.String, Projections.Property<ProjectEntity>(x => x.ProjectNumber)),
                like)
                ) && Restrictions.On<ProjectEntity>(x => x.Status).IsLike(status)
            ).List();
            return result;
        }
    }
}