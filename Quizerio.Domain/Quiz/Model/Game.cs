namespace Quizerio.Domain.Quiz.Model
{
    public class QuizGame
    {
        public QuizGame()
        {
        }

        public QuizGame(Quiz templateQuiz, Guid id, LinkedList<Question> questions, List<QuizGameParticipant> participants, QuizGameState state)
        {
            TemplateQuiz = templateQuiz;
            Id = id;
            Questions = questions;
            Participants = participants;
            State = state;
        }
        
        public Quiz TemplateQuiz { get; private set; }
        
        public Guid Id { get; private set; }

        private LinkedList<Question> Questions { get; set; }
        
        public List<QuizGameParticipant> Participants { get; private set; }
        
        public QuizGameState State { get; private set; }

        public QuizGameParticipant? Winner
        {
            get
            {
                if (State != QuizGameState.Finished)
                {
                    return null;
                }

                return Participants.MaxBy(p => p.Points);
            }
        }



        public void AssignPointsToParticipant(Guid participantId, short points)
        {
            Participants.First(x => x.Id == participantId).AddPoints(points);
        }

        public void Start()
        {
            State = QuizGameState.InProgress;
        }

        public void Finish()
        {
            State = QuizGameState.Finished;
            Participants.Sort((x, y) => x.Points.CompareTo(y.Points));
        }

        public void NextQuestion()
        {
            if (Questions.Count == 0)
            {
                return;
            }
            
            Questions.RemoveFirst();
        }

        public Question? CurrentQuestion()
        {
            return Questions.First();
        }

        public bool CanJoin()
        {
            return State == QuizGameState.NotStarted;
        }
    }

    public enum QuizGameState
    {
        NotStarted,
        InProgress,
        Finished,
    }
    
    public class QuizGameParticipant
    {
        public QuizGameParticipant() {}
        
        public QuizGameParticipant(Guid id, QuizGame quiz, string name, short points)
        {
            Id = id;
            Quiz = quiz;
            Name = name;
            Points = points;
        }

        public Guid Id { get; private set; }

        private QuizGame Quiz { get; set; }
        
        public string Name { get; private set; }


        public short Points { get; private set; } = 0;
        

        public void Join()
        {
            if (!Quiz.CanJoin())
            {
                return;
            }
            
            Quiz.Participants.Add(this);
        }

        public void AddPoints(short points)
        {
            Points += points;
        }
    }
}