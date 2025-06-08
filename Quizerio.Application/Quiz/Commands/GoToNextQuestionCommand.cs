namespace Quizerio.Application.Quiz.Commands
{
    public class GoToNextQuestionCommand
    {
        public GoToNextQuestionCommand(Guid gameId)
        {
            GameId = gameId;
        }

        public Guid GameId { get; set; }
    }
}