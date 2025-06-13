using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quizerio.Api.Middleware;
using Quizerio.Application;
using Quizerio.Application.Quiz;
using Quizerio.Application.User;
using Quizerio.Domain.Quiz.Ports;
using Quizerio.Domain.User.Model;
using Quizerio.Domain.User.Ports;
using Quizerio.Infrastructure;
using Quizerio.Infrastructure.Adapters;
using Quizerio.Infrastructure.Persistance;

namespace Quizerio.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataServices();
            services.AddApplicationServices();
            services.AddAuthServices(configuration);

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuizGameService, QuizGameService>();
            services.AddScoped<IQuizzFacade, QuizzFacade>();
            services.AddScoped<IUserFacade, UserFacade>();

            return services;
        }

        private static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<EfDbContext>(options =>
                options.UseSqlite("Data Source = Quizerio.db")
            );

            services.AddScoped<DataSeeder>();

            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IQuizGameRepository, QuizGameRepository>();


            return services;
        }

        private static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
            
            Console.WriteLine(jwtSettings);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKeys = new[]
                        {
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(jwtSettings.Key)
                            )
                        },
                        RoleClaimType = ClaimTypes.Role
                    };
                }
            );

            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("Moderator", policy => policy.RequireRole(UserRole.Moderator.ToString(), UserRole.Admin.ToString()));
                opts.AddPolicy("Admin", policy => policy.RequireRole(UserRole.Admin.ToString()));
            });

            services.AddScoped<CurrentUserMiddleware>();
            
            return services;
        }
    }
}