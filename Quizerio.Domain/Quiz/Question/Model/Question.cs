namespace Quizerio.Domain.Quizz
{
    public class Question
    {
        public Question(
            Guid questionId,
            string questionText,
            QuestionDifficulty difficulty,
            QuestionStatus status,
            List<Answer> answers
        )
        {
            Id = questionId;
            QuestionText = questionText;
            Difficulty = difficulty;
            Status = status;
            Answers = answers;
        }

        public Guid Id { get; }

        public string QuestionText;

        private QuestionStatus Status;

        public QuestionDifficulty Difficulty;

        public List<Answer> Answers { get; set; }
    }

    public record Answer
    {
        public string Text { get; set; }
        public Boolean IsCorrect { get; set; }
    }
}