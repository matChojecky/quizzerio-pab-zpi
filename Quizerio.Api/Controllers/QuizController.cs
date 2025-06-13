using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.User.Model;

namespace Quizerio.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private readonly IQuizzFacade _quizzFacade;
        
        public QuizController(ILogger<QuizController> logger, IQuizzFacade quizzFacade)
        {
            _logger = logger;
            _quizzFacade = quizzFacade;
        }
        
        [HttpPost]
        public IActionResult CreateQuiz([FromBody] CreateQuizCommand command)
        {
            _quizzFacade.CreateQuiz(command);
            return CreatedAtAction(null, null);
        }

        [HttpPost]
        [Route("{quizId}/questions/{questionId}")]
        public IActionResult AddQuestion(Guid quizId, Guid questionId)
        {
            var command = new AddQuestionToQuizCommand(quizId, questionId);
            
            _quizzFacade.AddQuestionToQuiz(command);
            
            return Ok();
        }
        
        [HttpDelete]
        [Route("{quizId}/questions/{questionId}")]
        public IActionResult DeleteQuestion(Guid quizId, Guid questionId)
        {
            //TODO: Implement removing questions
            
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUserQuizzes()
        {
            var me = HttpContext.Items["CurrentUser"] as User ?? throw new UnauthorizedAccessException();

            var query = new ListOwnedQuizQuery(me.Id);
            
            var quizes = _quizzFacade.GetUserQuizzes(query);
            return Ok(quizes);
        }
        
    }
}