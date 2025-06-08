using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.Commands
{
    public abstract class ChangeQuizGameStateCommand
    {
        protected ChangeQuizGameStateCommand(Guid quizId, QuizGameState nextState)
        {
            QuizId = quizId;
            NextState = nextState;
        }

        public Guid QuizId { get; set; }
        public QuizGameState NextState { get; set; }
    }

    public class StartQuizGameCommand : ChangeQuizGameStateCommand
    {
        public StartQuizGameCommand(Guid quizId) : base(quizId, QuizGameState.InProgress)
        {
        }
    }

    public class FinishQuizGameCommand : ChangeQuizGameStateCommand
    {
        public FinishQuizGameCommand(Guid quizId) : base(quizId, QuizGameState.Finished)
        {
        }
    }
}