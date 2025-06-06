namespace Quizerio.Domain.Quizz
{
    public interface IQuestionFacade
    {
        
        void ApproveQuestion(Guid questionId);
        void RejectQuestion(Guid questionId, string reason);
        
        Question GetQuestion(Guid questionId);
        List<Question> GetQuestions();
        void AddQuestion(QuestionWriteModel question);
        void AddQuestions(List<QuestionWriteModel> questions);
        void DeleteQuestion(Guid questionId);
        void EditQuestion(Guid questionId, QuestionWriteModel question);
    }
}