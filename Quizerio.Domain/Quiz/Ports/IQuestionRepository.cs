using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Domain.Quiz.Ports
{
    public interface IQuestionRepository
    {
        void UpdateQuestionStatus(Guid id, QuestionStatus status);

        void AddQuestion(Question question);

        void UpdateQuestion(Question question);

        Question GetQuestion(Guid questionId);

        List<Question> GetQuestions();

        void DeleteQuestion(Guid questionId);
    }
}