using Quizerio.Domain.Quiz.Model;

namespace Application.Quiz.Commands
{
    public class ChangeQuestionStatusCommand
    {
        public ChangeQuestionStatusCommand(Guid id, QuestionStatus status)
        {
            Id = id;
            Status = status;
        }

        public Guid Id { get; set; }
        public QuestionStatus Status { get; set; }
    }
}