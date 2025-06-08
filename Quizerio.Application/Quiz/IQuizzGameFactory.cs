using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz
{
    public interface IQuizzGameFactory
    {
        QuizGame CreateQuizGame(Domain.Quiz.Model.Quiz blueprint);
    }
}