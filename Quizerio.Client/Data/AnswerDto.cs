namespace Quizerio.Client.Data
{
    public class AnswerDto
    {
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = false;

        public Guid Id { get; set; } = Guid.Empty;
    }
}
