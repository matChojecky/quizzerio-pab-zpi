namespace Quizerio.Application.Quiz.Queries
{
    public class QuizWinnerQuery
    {
        public QuizWinnerQuery(Guid quizId)
        {
            QuizId = quizId;
        }

        public Guid QuizId { get; set; }
    }
}