using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Application
{
    public interface IUnitOfWork : IDisposable
    {
        public IQuestionRepository QuestionsRepository { get; }

        void Commit();
    }
}