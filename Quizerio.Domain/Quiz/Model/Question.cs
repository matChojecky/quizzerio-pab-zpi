namespace Quizerio.Domain.Quiz.Model
{
    public class Question
    {
        public Question(
            Guid questionId,
            string questionText,
            QuestionDifficulty difficulty,
            QuestionStatus status,
            List<Answer> answers,
            QuestionCategory category
        )
        {
            Id = questionId;
            QuestionText = questionText;
            Difficulty = difficulty;
            Status = status;
            Answers = answers;
            Category = category;
        }

        public Guid Id { get; private set; }

        public string QuestionText { get; private set; }

        public QuestionStatus Status { get; private set; }

        public QuestionDifficulty Difficulty { get; private set; }

        public List<Answer> Answers { get; private set; }

        public QuestionCategory Category { get; private set; }
    }

    public record Answer
    {
        public Answer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        public string Text { get; private set; }
        public bool IsCorrect { get; private set; }
    }
}