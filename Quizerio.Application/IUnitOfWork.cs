using Quizerio.Domain.Quiz.Ports;

namespace Application
{
    public interface IUnitOfWork : IDisposable
    {
        public IQuestionRepository QuestionsRepository { get; }

        void Commit();
    }
}