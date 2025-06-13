using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Application.Quiz.Queries
{
    public class ListQuestionsQuery
    {
        public QuestionDifficulty? Difficulty { get; set; }
        
        public QuestionStatus? Status { get; set; }
    }
}