using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.User.Model;

namespace Quizerio.Infrastructure.Persistance
{
    public class DataSeeder
    {
        private readonly EfDbContext _context;

        public DataSeeder(EfDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            
            if (!_context.Database.CanConnect())
            {
                return;
            }
            
            SeedUsers();
            SeedQuiz();
            
            _context.SaveChanges();
        }

        private void SeedUsers()
        {
            if (_context.Users.Any())
            {
                return;
            }
            
            
            _context.Users.AddRange(_users);
        }

        private void SeedQuiz()
        {
            if (_context.Quizs.Any())
            {
                return;
            }
            
            _context.QuestionCategories.AddRange(_questionCategories);
            _context.Questions.AddRange(_questions);

            var quiz = new Quiz(
                Guid.NewGuid(),
                _users.FirstOrDefault(u => u.Roles.Contains(UserRole.Standard))!.Id,
                _questions,
                "Test Quiz"
            );
            
            _context.Quizs.Add(quiz);
        }
        
        private static List<User> _users = new List<User>()
        {
            new User(
                Guid.NewGuid(),
                "testee",
                "testee@test.pl",
                "pass",
                new List<UserRole>() { UserRole.Standard },
                DateTime.Now,
                DateTime.Now
            ),
                
            new User(
                Guid.NewGuid(),
                "admin",
                "admin@test.pl",
                "admin",
                new List<UserRole>() { UserRole.Admin },
                DateTime.Now,
                DateTime.Now
            ),
                
            new User(
                Guid.NewGuid(),
                "moderator",
                "moderator@test.pl",
                "mod",
                new List<UserRole>() { UserRole.Moderator },
                DateTime.Now,
                DateTime.Now
            )
        };

        private static List<QuestionCategory> _questionCategories = new List<QuestionCategory>()
        {
            new QuestionCategory(
                "Ogólne",
                Guid.NewGuid()
            )
            
        };

        private static List<Question> _questions = new List<Question>()
        {
            new Question(
                Guid.NewGuid(),
                "Zaznacz Adam",
                QuestionDifficulty.Easy,
                QuestionStatus.Approved,
                new List<Answer>()
                {
                    new Answer(
                        Guid.NewGuid(),
                        "Adam",
                        true
                    ),
                    new Answer(
                        Guid.NewGuid(),
                        "XyZ",
                        false
                    ),
                    new Answer(
                        Guid.NewGuid(),
                        "XyZ",
                        false
                    ),
                    new Answer(
                        Guid.NewGuid(),
                        "XyZ",
                        false
                    )
                },
                _questionCategories.First()
            ),
        };
    }
}