using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.Commands
{
    public class CreateQuizCommand
    {
        public CreateQuizCommand(string name, List<Guid>? questions, Guid ownerId)
        {
            Name = name;
            Questions = questions;
            OwnerId = ownerId;
        }
        
        
        public List<Guid>? Questions { get; set; }
        
        public Guid OwnerId { get; set; }
        
        public string Name { get; set; }
        
    }
}