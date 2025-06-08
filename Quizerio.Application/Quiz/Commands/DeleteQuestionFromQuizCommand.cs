namespace Quizerio.Application.Quiz.Commands
{
    public class DeleteQuestionFromQuizCommand
    {
        public Guid QuizId { get; set; }
        
        public Guid QuestionId { get; set; }
    }
}