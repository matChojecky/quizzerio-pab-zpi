namespace Quizerio.Domain.Quizz
{
    public interface IQuestionService
    {
        void ChangeQuestionStatus(Guid id, QuestionStatus status);
        
        void AddQuestion(QuestionWriteModel question);
        void AddQuestions(List<QuestionWriteModel> questions);
        void DeleteQuestion(Guid questionId);
        void EditQuestion(Guid id, QuestionWriteModel question);
        
        Question GetQuestion(Guid questionId);
        List<Question> GetQuestions();
    }
}