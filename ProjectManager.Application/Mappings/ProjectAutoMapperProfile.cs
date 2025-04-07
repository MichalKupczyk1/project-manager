using AutoMapper;
using ProjectManager.Application.Handlers.ProjectHandlers.GetProject;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Mappings
{
    internal class ProjectAutoMapperProfile : Profile
    {
        public ProjectAutoMapperProfile()
        {
            CreateMap<Project, GetProjectResult>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(scr => scr.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(scr => scr.Description))
                .ForMember(dest => dest.OwnerLogin, opt => opt.MapFrom(scr => scr.Owner != null ? scr.Owner.Login : ""));
        }
    }
}
