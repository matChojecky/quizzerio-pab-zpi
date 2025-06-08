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
        public new Quiz GetById(Guid id)
        {
            var entity = QueryWithIncludes().FirstOrDefault(q => q.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Quiz with id {id} was not found.");
            }
            
            return entity;
        }

        protected override IQueryable<Quiz> QueryWithIncludes()
        {
            return _quizes.Include(q => q.Questions);
        }
    }
}