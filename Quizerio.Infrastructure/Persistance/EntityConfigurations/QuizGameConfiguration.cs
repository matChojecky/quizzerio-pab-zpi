using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Infrastructure.Persistance.EntityConfigurations
{
    public class QuizGameConfiguration : IEntityTypeConfiguration<QuizGame>
    {
        public void Configure(EntityTypeBuilder<QuizGame> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.State).HasConversion<int>().IsRequired();

            builder.HasOne(x => x.TemplateQuiz).WithMany().HasForeignKey("QuizId").IsRequired();

            builder.OwnsMany(
                qg => qg.Participants,
                participants =>
                {
                    participants.WithOwner().HasForeignKey("QuizGameId");

                    participants.HasKey(p => p.Id);

                    participants.Property(p => p.Id).ValueGeneratedNever();

                    participants.Property(p => p.Name)
                        .IsRequired()
                        .HasMaxLength(100);

                    participants.Property(p => p.Points)
                        .IsRequired();

                    participants.ToTable("QuizGameParticipants");
                }
            );
            builder
                .HasMany(typeof(Question), "Questions") // map the private field
                .WithMany()
                .UsingEntity(
                    "QuizGameQuestions", // join table name
                    right => right.HasOne(typeof(Question))
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left.HasOne(typeof(QuizGame))
                        .WithMany()
                        .HasForeignKey("QuizGameId")
                        .OnDelete(DeleteBehavior.Cascade),
                    join =>
                    {
                        join.HasKey("QuizGameId", "QuestionId");

                        // Order tracking
                        join.Property<int>("Order")
                            .IsRequired();

                        join.ToTable("QuizGameQuestions");
                    });

            builder.Metadata
                .FindNavigation("Questions")
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore(qg => qg.Winner);
        }
    }
}