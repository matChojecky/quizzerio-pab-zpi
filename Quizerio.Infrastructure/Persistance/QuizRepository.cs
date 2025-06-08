using Microsoft.EntityFrameworkCore;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private readonly EfDbContext _dbContext;
        private readonly DbSet<Quiz> _quizes;
        
        public QuizRepository(EfDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _quizes = dbContext.Set<Quiz>();
        }
    }
}