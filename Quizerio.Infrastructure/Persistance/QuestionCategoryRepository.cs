using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class QuestionCategoryRepository : Repository<QuestionCategory>, IQuestionCategoryRepository
    {
        public QuestionCategoryRepository(EfDbContext dbContext) : base(dbContext)
        {
        }
    }
}