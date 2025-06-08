namespace Quizerio.Application.Quiz.Commands
{
    public class AddPointsToParticipantCommand
    {
        public AddPointsToParticipantCommand(Guid gameId, Guid participantId, short points = 1)
        {
            GameId = gameId;
            ParticipantId = participantId;
            Points = points;
        }

        public Guid GameId { get; set; }
        
        public Guid ParticipantId { get; set; }
        
        public short Points { get; set; }
    }
}