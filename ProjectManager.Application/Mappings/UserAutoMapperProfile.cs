using AutoMapper;
using ProjectManager.Application.Handlers.UserHandlers.GetUser;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Mappings
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<User, GetUserResult>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(scr => scr.Email))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(scr => scr.Login));
        }
    }
}
