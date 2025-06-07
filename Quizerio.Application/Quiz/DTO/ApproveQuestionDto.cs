namespace Application.Quiz.DTO
{
    public abstract class ApproveQuestionDto
    {
        public ApproveQuestionDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}