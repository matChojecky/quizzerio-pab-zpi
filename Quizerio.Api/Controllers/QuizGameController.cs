using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Api.Controllers
{
    [Authorize]
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
            
            var id = _quizzFacade.CreateQuizGame(command);
            
            return CreatedAtAction(null, id);
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
        
        [HttpGet]
        [Route("{quizGameId}/participants")]
        public IActionResult GetParticipantsOfQuizGame(Guid quizGameId)
        {
            var query = new ListQuizGameParticipants(quizGameId);
            var participants = _quizzFacade.GetQuizParticipants(query);
            
            return Ok(participants);
        }

        [HttpGet]
        [Route("{quizGameId}/winner")]
        public IActionResult GetWinner(Guid quizGameId)
        {
            var query = new QuizWinnerQuery(quizGameId);
            
            var winner = _quizzFacade.GetQuizWinner(query);
            
            return Ok(winner);
        }

        [HttpGet]
        [Route("{quizGameId}/current")]
        public IActionResult GetCurrentQuizGame(Guid quizGameId)
        {
            var query = new CurrentQuestionQuery(quizGameId);
            var question = _quizzFacade.GetCurrentQuizQuestion(query);
            
            return Ok(question);
        }
    }
}