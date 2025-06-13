using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;

namespace Quizerio.Api.Controllers
{
    [Authorize("Moderator")]
    [ApiController]
    [Route("[controller]")]
    public class QuestionCategoryController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuizzFacade _quizzFacade;

        public QuestionCategoryController(ILogger<QuestionController> logger, IQuizzFacade quizzFacade)
        {
            _logger = logger;
            _quizzFacade = quizzFacade;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddQuestionCategoryCommand command)
        {
            _quizzFacade.AddQuestionCategory(command);

            return CreatedAtAction(null, null);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ListAll()
        {
            var categories = _quizzFacade.GetQuestionCategories();

            return Ok(categories);
        }
    }
}