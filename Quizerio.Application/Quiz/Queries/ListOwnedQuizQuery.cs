namespace Quizerio.Application.Quiz.Queries
{
    public class ListOwnedQuizQuery
    {
        public ListOwnedQuizQuery(Guid ownerId)
        {
            OwnerId = ownerId;
        }

        public Guid OwnerId { get; set; }
        
        
    }
}