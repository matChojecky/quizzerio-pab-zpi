using Quizerio.Application;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EfDbContext _context;

        public EfUnitOfWork(
            EfDbContext context,
            IQuestionRepository questionsRepository
        )
        {
            _context = context;
            QuestionsRepository = questionsRepository;
        }

        public IQuestionRepository QuestionsRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}