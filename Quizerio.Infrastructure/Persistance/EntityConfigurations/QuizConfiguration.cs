using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.User.Model;

namespace Quizerio.Infrastructure.Persistance.EntityConfigurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> configuration)
        {
            configuration
                .HasKey(x => x.Id);

            configuration
                .Property(x => x.Id)
                .ValueGeneratedNever();

            configuration
                .Property(q => q.Name)
                .IsRequired();

            configuration
                .HasMany(
                    typeof(Question),
                    "Questions"
                )
                .WithMany()
                .UsingEntity(
                    "QuizQuestions",
                    right => right.HasOne(typeof(Question))
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left.HasOne(typeof(Quiz))
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade),
                    join =>
                    {
                        join.HasKey("QuizId", "QuestionId");

                        // Optional: ordering column
                        join.Property<int>("Order")
                            .IsRequired();

                        join.ToTable("QuizQuestions");
                    }
                );

            configuration.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}