using Application.Quiz.DTO;
using Quizerio.Domain.Quiz.Model;

namespace Application.Quiz.Commands
{
    public record UpdateQuestionCommand : QuestionWriteModel
    {
        public UpdateQuestionCommand(
            Guid id,
            string questionText,
            QuestionDifficulty difficulty,
            List<AnswerWriteModel> answers,
            Guid categoryId
        ) : base(questionText, difficulty, answers, categoryId)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}