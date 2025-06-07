using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.DTO
{
    public class QuestionWriteModel
    {
        public List<AnswerWriteModel> Answers { get; set; }

        public Guid CategoryId { get; set; }

        public QuestionDifficulty Difficulty { get; set; }
        
        public string QuestionText { get; set; }
        
        public QuestionWriteModel() {}

        protected QuestionWriteModel(string questionText, QuestionDifficulty difficulty, List<AnswerWriteModel> answers,
            Guid categoryId)
        {
            QuestionText = questionText;
            Difficulty = difficulty;
            Answers = answers;
            CategoryId = categoryId;
        }
    }

    public class AnswerWriteModel
    {
        public Guid? Id { get; set; }
        public bool IsCorrect { get; set; }
        public string Text { get; set; }

        public AnswerWriteModel() {}
        protected AnswerWriteModel(Guid? id, string text, bool isCorrect)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}