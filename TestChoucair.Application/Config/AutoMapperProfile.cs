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
            CreateMap<User, SignInResponseDto>();
            CreateMap<User, SignUpResponseDto>();


            // Request Class
            CreateMap<TaskRequestDto, TaskUser>();
            CreateMap<SignInRequestDto, User >();
            CreateMap<SignUpRequestDto, User>();

        }
    }
}