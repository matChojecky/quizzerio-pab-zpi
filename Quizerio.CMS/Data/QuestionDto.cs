namespace Quizerio.CMS.Data
{
    public class QuestionDto
    {
        public Guid Id { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public string Difficulty { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public AnswerDto[] Answers { get; set; } = new AnswerDto[4]
        {
            new(), new(), new(), new()
        };

        public Guid CategoryId { get; set; } = Guid.Empty;
    }
}