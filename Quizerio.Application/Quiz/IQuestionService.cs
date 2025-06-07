using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz
{
    public interface IQuestionService
    {
        void ChangeQuestionStatus(ChangeQuestionStatusCommand command);

        void AddQuestion(CreateQuestionCommand question);
        void DeleteQuestion(DeleteQuestionCommand command);
        void UpdateQuestion(UpdateQuestionCommand updateQuestion);

        Question GetQuestion(GetQuestionQuery query);
        List<Question> GetQuestions(ListQuestionsQuery query);
    }
}