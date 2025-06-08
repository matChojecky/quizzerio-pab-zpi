using Microsoft.EntityFrameworkCore;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class QuizGameRepository : Repository<QuizGame>, IQuizGameRepository
    {
        private readonly DbSet<QuizGame> _quizGames;

        public QuizGameRepository(EfDbContext dbContext) : base(dbContext)
        {
            _quizGames = dbContext.Set<QuizGame>();
        }

        public void UpdateQuizGameState(Guid id, QuizGameState status)
        {
            _quizGames
                .Where(qg => qg.Id == id)
                .ExecuteUpdate(
                    q => q.SetProperty(
                        it => it.State, status
                    )
                );
        }

        public new QuizGame GetById(Guid id)
        {
            var entity = QueryWithIncludes().FirstOrDefault(qg => qg.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Quiz game with id {id} was not found.");
            }
            
            return entity;
        }

        protected override IQueryable<QuizGame> QueryWithIncludes()
        {
            return _quizGames
                .Include(q => q.Participants)
                .Include("Questions.Category")
                .Include(q => q.TemplateQuiz);
        }
    }
}