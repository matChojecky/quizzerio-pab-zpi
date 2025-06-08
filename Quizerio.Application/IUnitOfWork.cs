using Quizerio.Domain.Quiz.Ports;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Application
{
    public interface IUnitOfWork : IDisposable
    {
        public IQuestionRepository QuestionsRepository { get; }
        
        public IQuestionCategoryRepository QuestionCategoriesRepository { get; }
        public IUserRepository UsersRepository { get; }
        
        public IQuizRepository QuizRepository { get; }
        
        public IQuizGameRepository QuizGameRepository { get; }

        void Commit();
    }
}