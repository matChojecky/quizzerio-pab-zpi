namespace Quizerio.Application.Quiz.Commands
{
    public class AddQuestionToQuizCommand
    {
        public AddQuestionToQuizCommand(Guid quizId, Guid questionId)
        {
            QuizId = quizId;
            QuestionId = questionId;
        }

        public Guid QuizId { get; set; }
        
        public Guid QuestionId { get; set; }
    }
}