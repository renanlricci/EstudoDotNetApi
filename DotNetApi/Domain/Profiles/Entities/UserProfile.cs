using AutoMapper;
using DotNetApi.Domain.Commands.User;
using DotNetApi.Domain.Queries.User;

namespace DotNetApi.Domain.Profiles.Entities
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserCommand, Domain.Entities.User>(MemberList.None);

            CreateMap<UpdateUserCommand, Domain.Entities.User>(MemberList.None);

            CreateMap<Domain.Entities.User, GetAllUserQueryResponse>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<Domain.Entities.User, GetUserByIdQueryResponse>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
