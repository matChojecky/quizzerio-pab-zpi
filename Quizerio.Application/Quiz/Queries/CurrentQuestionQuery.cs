namespace Quizerio.Application.Quiz.Queries
{
    public class CurrentQuestionQuery
    {
        public CurrentQuestionQuery(Guid quizId)
        {
            QuizId = quizId;
        }

        public Guid QuizId { get; set; }
    }
}