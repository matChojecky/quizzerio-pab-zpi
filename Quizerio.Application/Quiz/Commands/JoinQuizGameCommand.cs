namespace Quizerio.Application.Quiz.Commands
{
    public class JoinQuizGameCommand
    {
        public JoinQuizGameCommand(Guid quizId, string name)
        {
            QuizId = quizId;
            Name = name;
        }

        public Guid QuizId { get; set; }
        public string Name { get; set; }
    }
}