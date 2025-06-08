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
            
            _context.SaveChanges();
        }

        private void SeedUsers()
        {
            if (_context.Users.Any())
            {
                return;
            }
            
            var users = new List<User>()
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
            
            _context.Users.AddRange(users);
        }
    }
}