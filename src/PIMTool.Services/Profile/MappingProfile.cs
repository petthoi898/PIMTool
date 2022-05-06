using AutoMapper;
using PIMTool.Common.BusinessObjects;
using PIMTool.Services.Service.Entities;
using Group = PIMTool.Common.BusinessObjects.Group;

namespace PIMTool.Services.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectEmployee, Member>();
            CreateMap<EmployeeEntity, Employee>().ReverseMap();
            CreateMap<ProjectEmployeeEntity, ProjectEmployee>().ReverseMap();
            CreateMap<ProjectEntity, Project>()
                .ForMember(x => x.IsChecked, opt => opt.Ignore())
                .ForMember(x => x.IsShowButton, opt => opt.Ignore())
                .ForMember(x => x.Members, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<GroupEntity, Group>()
                .ForMember(x => x.GroupNameId, opt => opt.Ignore()).ReverseMap();
        }
    }
}