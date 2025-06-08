using Microsoft.EntityFrameworkCore;
using Quizerio.Application;
using Quizerio.Application.Quiz;
using Quizerio.Application.User;
using Quizerio.Domain.Quiz.Ports;
using Quizerio.Domain.User.Ports;
using Quizerio.Infrastructure.Adapters;
using Quizerio.Infrastructure.Persistance;

namespace Quizerio.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDataServices();
            services.AddApplicationServices();

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
    }
}