using Quizerio.Application;
using Quizerio.Domain.Quiz.Ports;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EfDbContext _context;

        public EfUnitOfWork(
            EfDbContext context,
            IQuestionRepository questionsRepository, IQuestionCategoryRepository questionCategoryRepository, IUserRepository userRepository)
        {
            _context = context;
            QuestionsRepository = questionsRepository;
            QuestionCategoryRepository = questionCategoryRepository;
            UserRepository = userRepository;
        }

        public IQuestionRepository QuestionsRepository { get; }
        public IQuestionCategoryRepository QuestionCategoryRepository { get; }
        public IUserRepository UserRepository { get; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}