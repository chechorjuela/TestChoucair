using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestChoucair.Domain.Repository;
using TestChoucair.Infrastructure.Helpers;
using TestChoucair.Infrastructure.Repository;

namespace TestChoucair.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();


            var connectionString = configuration.GetConnectionString("ConnectionString")
             ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });



            services.AddScoped<JwtTokenService>();

            var validIssuer = configuration.GetValue<string>("Jwt:Issuer");
            var validAudience = configuration.GetValue<string>("Jwt:Audience");
            var key = Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

            return services;
        }
    }
}
