namespace Quizerio.Application.Quiz.Queries
{
    public class GetQuestionQuery
    {
        public GetQuestionQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}