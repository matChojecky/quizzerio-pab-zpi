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
    }
}