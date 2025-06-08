namespace Quizerio.Application.Quiz.Queries
{
    public class ListQuizGameParticipants
    {
        public ListQuizGameParticipants(Guid quizId)
        {
            QuizId = quizId;
        }

        public Guid QuizId { get; set; }
    }
}