using System;

namespace Quizerio.Domain.Quiz.Model
{
    public class QuestionCategory
    {
        public QuestionCategory(string name, Guid id)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}