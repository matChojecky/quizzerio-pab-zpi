using Application.Quiz.DTO;
using Quizerio.Domain.Quiz.Model;

namespace Application.Quiz
{
    public interface IQuizzFacade
    {
        void ApproveQuestion(ApproveQuestionDto approveQuestionDto);
        void RejectQuestion(RejectQuestionDto rejectQuestionDto);

        Question GetQuestion(Guid questionId);
        List<Question> GetQuestions();
        void AddQuestion(QuestionWriteModel question);
        void AddQuestions(List<QuestionWriteModel> questions);
        void DeleteQuestion(Guid questionId);
        void EditQuestion(Guid questionId, QuestionWriteModel question);
    }
}