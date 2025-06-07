using Quizerio.Domain.Quiz.Model;

namespace Application.Quiz.DTO
{
    public record QuestionWriteModel
    {
        public List<AnswerWriteModel> Answers;

        public Guid CategoryId;

        public QuestionDifficulty Difficulty;
        public string QuestionText;

        public QuestionWriteModel(string questionText, QuestionDifficulty difficulty, List<AnswerWriteModel> answers,
            Guid categoryId)
        {
            QuestionText = questionText;
            Difficulty = difficulty;
            Answers = answers;
            CategoryId = categoryId;
        }
    }

    public record AnswerWriteModel
    {
        public bool IsCorrect;
        public string Text;

        public AnswerWriteModel(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}