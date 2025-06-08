using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Adapters
{
    public class QuizGameService : IQuizGameService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IQuizGameRepository _quizGameRepository;


        public QuizGameService(IQuizRepository quizRepository, IQuizGameRepository quizGameRepository)
        {
            _quizRepository = quizRepository;
            _quizGameRepository = quizGameRepository;
        }

        public Guid CreateQuizGame(CreateQuizGameCommand command)
        {
            var templateQuiz = _quizRepository.GetById(command.QuizId);
            var questionsList = new LinkedList<Question>();
            templateQuiz.Questions.ForEach(question => questionsList.AddLast(question));

            var quizGame = new QuizGame(
                templateQuiz,
                Guid.NewGuid(),
                questionsList,
                new List<QuizGameParticipant>(),
                QuizGameState.NotStarted
            );

            _quizGameRepository.Add(quizGame);

            return quizGame.Id;
        }

        public void AddPointsToParticipant(AddPointsToParticipantCommand command)
        {
            var quizGame = _quizGameRepository.GetById(command.GameId);
            var participant = quizGame.Participants.FirstOrDefault(x => x.Id == command.ParticipantId);

            if (participant == null)
            {
                throw new ArgumentException("Invalid participant id");
            }

            participant.AddPoints(command.Points);

            _quizGameRepository.Update(quizGame);
        }

        public void GoToNextQuestion(GoToNextQuestionCommand command)
        {
            var quizGame = _quizGameRepository.GetById(command.GameId);
            quizGame.NextQuestion();
            _quizGameRepository.Update(quizGame);
        }

        public void ChangeQuizGameState(ChangeQuizGameStateCommand command)
        {
            _quizGameRepository.UpdateQuizGameState(command.QuizId, command.NextState);
        }

        public void JoinQuizGame(JoinQuizGameCommand command)
        {
            var quizGame = _quizGameRepository.GetById(command.QuizId)
                            ?? throw new ArgumentException("Invalid quiz game id");

            var participant = new QuizGameParticipant(
                Guid.NewGuid(),
                quizGame,
                command.Name,
                0
            );
            
            participant.Join();
            
            _quizGameRepository.Update(quizGame);
        }

        public QuizGame GetQuizGame(Guid quizGameId)
        {
            return _quizGameRepository.GetById(quizGameId);
        }
    }
}