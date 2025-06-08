using Quizerio.Domain.Common;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Domain.Quiz.Ports
{
    public interface IQuizGameRepository : IRepository<QuizGame>
    {
        void UpdateQuizGameState(Guid id, QuizGameState status);
    }
}