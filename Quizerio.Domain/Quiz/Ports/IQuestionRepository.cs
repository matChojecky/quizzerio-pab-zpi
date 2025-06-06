using Quizerio.Domain.Quizz;

namespace Quizerio.Domain.Question.Ports
{
    public interface IQuestionRepository
    {
        void UpdateQuestionStatus(Guid id, QuestionStatus status);
        
        void AddQuestion(Quizz.Question question);
        
        Quizz.Question GetQuestion(Guid questionId);
        
        void DeleteQuestion(Guid questionId);
        
    }
}