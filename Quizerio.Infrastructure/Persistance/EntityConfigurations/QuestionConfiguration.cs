using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Infrastructure.Persistance.EntityConfigurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> configuration)
        {
            configuration
                .HasKey(x => x.Id);

            configuration
                .Property(q => q.QuestionText)
                .IsRequired();

            configuration
                .Property(q => q.Difficulty)
                .HasConversion<string>();

            configuration
                .Property("Status")
                .HasConversion<string>();

            // OwnsMany to separate table
            configuration
                .OwnsMany(
                    q => q.Answers,
                    a =>
                    {
                        a.ToTable("Answers"); // Separate table
                        a.WithOwner().HasForeignKey("QuestionId");

                        a.HasKey(a => a.Id);

                        a.Property(p => p.Text).IsRequired();
                        a.Property(p => p.IsCorrect).IsRequired();
                    }
                );

            configuration
                .HasOne<QuestionCategory>(q => q.Category)
                .WithMany()
                .HasForeignKey("CategoryId")
                .IsRequired();
        }
    }
}