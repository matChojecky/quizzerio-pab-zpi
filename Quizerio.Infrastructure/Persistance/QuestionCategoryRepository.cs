using Microsoft.EntityFrameworkCore;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class QuestionCategoryRepository : Repository<QuestionCategory>, IQuestionCategoryRepository
    {
        public QuestionCategoryRepository(EfDbContext dbContext) : base(dbContext)
        {
            QuestionCategories = dbContext.Set<QuestionCategory>();
        }

        public DbSet<QuestionCategory> QuestionCategories { get; set; }
    }
}