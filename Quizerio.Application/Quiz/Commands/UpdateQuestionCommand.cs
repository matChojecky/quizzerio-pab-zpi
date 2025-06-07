using Quizerio.Application.Quiz.DTO;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.Commands
{
    public class UpdateQuestionCommand : QuestionWriteModel
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