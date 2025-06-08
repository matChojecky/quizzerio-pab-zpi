using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Infrastructure.Adapters
{
    public class QuizGameService : IQuizGameService
    {
        public Guid CreateQuizGame(CreateQuizGameCommand command)
        {
            throw new NotImplementedException();
        }

        public void AddPointsToParticipant(AddPointsToParticipantCommand command)
        {
            throw new NotImplementedException();
        }

        public void GoToNextQuestion(GoToNextQuestionCommand command)
        {
            throw new NotImplementedException();
        }

        public void ChangeQuizGameState(ChangeQuizGameStateCommand command)
        {
            throw new NotImplementedException();
        }

        public void JoinQuizGame(JoinQuizGameCommand command)
        {
            throw new NotImplementedException();
        }

        public QuizGame GetQuizGame(Guid quizGameId)
        {
            throw new NotImplementedException();
        }
    }
}