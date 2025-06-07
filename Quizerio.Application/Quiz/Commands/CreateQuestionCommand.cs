using Quizerio.Application.Quiz.DTO;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.Commands
{
    public class CreateQuestionCommand : QuestionWriteModel
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