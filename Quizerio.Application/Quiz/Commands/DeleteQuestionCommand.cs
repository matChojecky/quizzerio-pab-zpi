namespace Application.Quiz.Commands
{
    public class DeleteQuestionCommand
    {
        public DeleteQuestionCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}