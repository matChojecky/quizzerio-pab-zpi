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
    }
}