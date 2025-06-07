using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.Commands
{
    public abstract class ChangeQuestionStatusCommand
    {
        protected ChangeQuestionStatusCommand(Guid id, QuestionStatus status)
        {
            Id = id;
            Status = status;
        }

        public Guid Id { get; set; }
        public QuestionStatus Status { get; set; }
    }

    public class ApproveQuestionCommand : ChangeQuestionStatusCommand
    {
        public ApproveQuestionCommand(Guid id) : base(id, QuestionStatus.Approved)
        {
        }
    }

    public class RejectQuestionCommand : ChangeQuestionStatusCommand
    {
        public RejectQuestionCommand(Guid id, string reason) : base(id, QuestionStatus.Rejected)
        {
            Reason = reason;
        }

        public string Reason { get; private set; }
    }
}