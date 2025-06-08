using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz
{
    public interface IQuizzFacade
    {
        void ApproveQuestion(ApproveQuestionCommand command);
        void RejectQuestion(RejectQuestionCommand command);

        Question GetQuestion(GetQuestionQuery query);
        List<Question> GetQuestions(ListQuestionsQuery query);
        void AddQuestion(CreateQuestionCommand command);
        void DeleteQuestion(DeleteQuestionCommand command);
        void EditQuestion(UpdateQuestionCommand command);

        void AddQuestionCategory(AddQuestionCategoryCommand command);

        List<QuestionCategory> GetQuestionCategories();
        
        void CreateQuiz(CreateQuizCommand command);
        
        void AddQuestionToQuiz(AddQuestionToQuizCommand command);
        
        List<Domain.Quiz.Model.Quiz> GetUserQuizzes(ListOwnedQuizQuery query);
        
        Guid CreateQuizGame(CreateQuizGameCommand command);
        
        void AddPointsToParticipant(AddPointsToParticipantCommand command);
        
        void GoToNextQuestion(GoToNextQuestionCommand command);

        void ChangeQuizGameState(ChangeQuizGameStateCommand command);
        
        void JoinQuizGame(JoinQuizGameCommand command);
        
        Question? GetCurrentQuizQuestion(CurrentQuestionQuery query);
        
        QuizGameParticipant? GetQuizWinner(QuizWinnerQuery query);
        
        
    }
}