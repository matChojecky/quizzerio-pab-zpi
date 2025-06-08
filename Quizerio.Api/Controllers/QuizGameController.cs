using Microsoft.AspNetCore.Mvc;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizGameController : ControllerBase
    {
        private readonly IQuizzFacade _quizzFacade;

        public QuizGameController(IQuizzFacade quizzFacade)
        {
            _quizzFacade = quizzFacade;
        }

        [HttpPost]
        [Route("{quizId}")]
        public IActionResult CreateQuizGame(Guid quizId)
        {
            var command = new CreateQuizGameCommand(quizId);
            
            _quizzFacade.CreateQuizGame(command);
            
            return CreatedAtAction(null, null);
        }

        [HttpPatch]
        [Route("{quizGameId}/participants/{participantId}/points")]
        public IActionResult AddPointsToParticipant(Guid quizGameId, Guid participantId)
        {
            var command = new AddPointsToParticipantCommand(quizGameId, participantId);
            
            _quizzFacade.AddPointsToParticipant(command);
            
            return NoContent();
        }

        [HttpPatch]
        [Route("{quizGameId}/progress/next-question")]
        public IActionResult GoToNextQuestion(Guid quizGameId)
        {
            _quizzFacade.GoToNextQuestion(new GoToNextQuestionCommand(quizGameId));
            
            return NoContent();
        }

        [HttpPatch]
        [Route("{quizGameId}/progress/start")]
        public IActionResult StartQuizGame(Guid quizGameId)
        {
            _quizzFacade.ChangeQuizGameState(new StartQuizGameCommand(quizGameId));
            return NoContent();
        }

        [HttpPatch]
        [Route("{quizGameId}/progress/end")]
        public IActionResult EndQuizGame(Guid quizGameId)
        {
            _quizzFacade.ChangeQuizGameState(new FinishQuizGameCommand(quizGameId));
            return NoContent();
        }

        [HttpPost]
        [Route("{quizGameId}/participants")]
        public IActionResult AddParticipantToQuizGame(Guid quizGameId, [FromBody] string participantName)
        {
            var command = new JoinQuizGameCommand(quizGameId, participantName);
            _quizzFacade.JoinQuizGame(command);
            
            return NoContent();
        }
    }
}