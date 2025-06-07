using Microsoft.EntityFrameworkCore;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.User.Model;
using Quizerio.Infrastructure.Persistance.EntityConfigurations;

namespace Quizerio.Infrastructure.Persistance
{
    public sealed class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new QuestionConfiguration())
                .ApplyConfiguration(new QuestionCategoryConfiguration());
        }
    }
}