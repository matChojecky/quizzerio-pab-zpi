using Quizerio.Domain.Common;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Domain.Quiz.Ports
{
    public interface IQuestionRepository : IRepository<Question>
    {
        void UpdateQuestionStatus(Guid id, QuestionStatus status);
    }
}