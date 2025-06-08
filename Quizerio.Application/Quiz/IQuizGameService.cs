using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz
{
    public interface IQuizGameService
    {
        
        Guid CreateQuizGame(CreateQuizGameCommand command);
        
        void AddPointsToParticipant(AddPointsToParticipantCommand command);
        
        void GoToNextQuestion(GoToNextQuestionCommand command);

        void ChangeQuizGameState(ChangeQuizGameStateCommand command);
        
        void JoinQuizGame(JoinQuizGameCommand command);
        
        QuizGame GetQuizGame(Guid quizGameId);
        
        List<QuizGameParticipant> GetQuizGameParticipants(ListQuizGameParticipants query);
    }
}