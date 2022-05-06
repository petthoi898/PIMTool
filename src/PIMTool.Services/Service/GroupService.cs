using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Criterion;
using PIMTool.Services.Service.Entities;
using PIMTool.Services.Service.Generic;
using PIMTool.Services.Service.Pattern;
using PIMTool.Services.Service.Repository;

namespace PIMTool.Services.Service
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        private readonly IGroupRepository _groupRepository;

        public GroupService(IUnitOfWorkProvider unitOfWorkProvider,
            IGroupRepository groupRepository)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
            _groupRepository = groupRepository;
        }

        public IList<Entities.GroupEntity> GetAll()
        {
            IList<Entities.GroupEntity> result;
            using (var scope = _unitOfWorkProvider.Provide())
            {
                result = _groupRepository.GetAll();
                scope.Complete();
            }
            return result;
        }

        public Entities.GroupEntity GetById(int projectId)
        {
            return _unitOfWorkProvider.PerformActionInUnitOfWork<Entities.GroupEntity>(() => _groupRepository.GetById(projectId));
        }


    }
}