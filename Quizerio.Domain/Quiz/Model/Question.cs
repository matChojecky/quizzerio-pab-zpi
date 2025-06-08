using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizerio.Domain.Quiz.Model
{
    public class Question
    {
        private Question()
        {
        }

        public Question(
            Guid questionId,
            string questionText,
            QuestionDifficulty difficulty,
            QuestionStatus status,
            List<Answer> answers,
            QuestionCategory category
        )
        {
            if (answers == null) throw new ArgumentNullException(nameof(answers));

            if (answers.Count != 4) throw new ArgumentException("A question must have exactly 4 answers.");

            if (answers.Count(a => a.IsCorrect) != 1)
                throw new ArgumentException("A question must have exactly one correct.");

            Id = questionId;
            QuestionText = questionText;
            Difficulty = difficulty;
            Status = status;
            Answers = answers;
            Category = category;
        }

        public Guid Id { get; set; }

        public string QuestionText { get; set; }

        public QuestionStatus Status { get; set; }

        public QuestionDifficulty Difficulty { get; set; }

        public List<Answer> Answers { get; set; } = new();

        public QuestionCategory Category { get; set; }
    }

    public record Answer
    {
        public Answer(Guid id, string text, bool isCorrect)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
        }

        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; }
    }
}