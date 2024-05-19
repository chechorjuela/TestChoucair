using AutoMapper;
using TestChoucair.Application.Dto;
using TestChoucair.Domain.Model;

namespace TestChoucair.Domain.Config
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // Response Class
            CreateMap<TaskUser, TaskResponseDto>();
            CreateMap<User, SignInResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Token, opt => opt.Ignore());
                
            CreateMap<User, SignUpResponseDto>();


            // Request Class
            CreateMap<TaskRequestDto, TaskUser>();
            CreateMap<SignInRequestDto, User >();
            CreateMap<SignUpRequestDto, User>();

        }
    }
}