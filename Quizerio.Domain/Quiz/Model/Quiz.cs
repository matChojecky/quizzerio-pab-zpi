namespace Quizerio.Domain.Quiz.Model
{
    public class Quiz
    {
        public Quiz() {}
        public Quiz(Guid id, Guid ownerId, List<Question> questions, string name)
        {
            Id = id;
            OwnerId = ownerId;
            Questions = questions;
            Name = name;
        }

        public Guid Id { get; private set; }
        
        public Guid OwnerId { get; private set; }
        
        public string Name { get; private set;  }
        public List<Question> Questions { get; private set; }


        public void AddQuestion(Question question)
        {
            if (Questions.Contains(question))
            {
                return;
            }
            
            Questions.Add(question);
        }

        public void RemoveQuestion(Question question)
        {
            Questions.Remove(question);
        }
    }

    
}