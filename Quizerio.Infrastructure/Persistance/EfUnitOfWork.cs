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
            IQuestionRepository questionsRepository, IQuestionCategoryRepository questionCategoryRepository,
            IUserRepository userRepository, IQuestionCategoryRepository questionCategoriesRepository,
            IUserRepository usersRepository, IQuizRepository quizRepository, IQuizGameRepository quizGameRepository)
        {
            _context = context;
            QuestionsRepository = questionsRepository;
            QuestionCategoryRepository = questionCategoryRepository;
            UserRepository = userRepository;
            QuestionCategoriesRepository = questionCategoriesRepository;
            UsersRepository = usersRepository;
            QuizRepository = quizRepository;
            QuizGameRepository = quizGameRepository;
        }

        public IQuestionRepository QuestionsRepository { get; }
        public IQuestionCategoryRepository QuestionCategoriesRepository { get; }
        public IUserRepository UsersRepository { get; }
        public IQuizRepository QuizRepository { get; }
        public IQuizGameRepository QuizGameRepository { get; }
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