namespace Quizerio.Application.User.Queries
{
    public class GetUserQuery
    {
        public GetUserQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}