using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.DTO
{
    public class QuestionWriteModel
    {
        public readonly List<AnswerWriteModel> Answers;

        public Guid CategoryId;

        public readonly QuestionDifficulty Difficulty;
        
        public readonly string QuestionText;

        protected QuestionWriteModel(string questionText, QuestionDifficulty difficulty, List<AnswerWriteModel> answers,
            Guid categoryId)
        {
            QuestionText = questionText;
            Difficulty = difficulty;
            Answers = answers;
            CategoryId = categoryId;
        }
    }

    public abstract class AnswerWriteModel
    {
        public readonly bool IsCorrect;
        public readonly string Text;

        protected AnswerWriteModel(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}