using Application.Quiz.DTO;
using Quizerio.Domain.Quiz.Model;

namespace Application.Quiz.Commands
{
    public record CreateQuestionCommand : QuestionWriteModel
    {
        public CreateQuestionCommand(
            string questionText,
            QuestionDifficulty difficulty,
            List<AnswerWriteModel> answers,
            Guid categoryId
        ) : base(questionText, difficulty, answers, categoryId)
        {
        }
    }
}