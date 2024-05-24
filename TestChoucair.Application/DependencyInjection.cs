using Choucair.Application.Service;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestChoucair.Application.Dto;
using TestChoucair.Application.Service;
using TestChoucair.Application.Services;
using TestChoucair.Application.Validator;
using TestChoucair.Domain.Config;
using TestChoucair.Infrastructure;

namespace TestChoucair.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationInjection(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);

            services.AddAutoMapper(typeof(AutoMappingProfile));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITaskService, TaskService>();


            services.AddTransient<IValidator<SignUpRequestDto>, SingUpValidator>();
            services.AddTransient<IValidator<SignInRequestDto>, SignInValidator>();
            services.AddTransient<IValidator<TaskRequestDto>, TaskCreateValidator>();


            return services;
        }
    }
}
