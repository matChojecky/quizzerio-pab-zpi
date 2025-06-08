using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.Commands
{
    public class CreateQuizGameCommand
    {
        public CreateQuizGameCommand(Guid quizId)
        {
            QuizId = quizId;
        }

        public Guid QuizId { get; set; }
    }
}