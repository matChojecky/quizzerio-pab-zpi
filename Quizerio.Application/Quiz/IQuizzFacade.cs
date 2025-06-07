using Application.Quiz.Commands;
using Application.Quiz.DTO;
using Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;

namespace Application.Quiz
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
    }
}