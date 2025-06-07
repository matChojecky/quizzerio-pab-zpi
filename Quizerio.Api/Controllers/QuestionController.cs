using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.DTO;
using Quizerio.Application.Quiz.Queries;

namespace Quizerio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuizzFacade _quizzFacade;

        public QuestionController(ILogger<QuestionController> logger, IQuizzFacade quizzFacade)
        {
            _logger = logger;
            _quizzFacade = quizzFacade;
        }

        [HttpPost]
        public IActionResult Create([FromBody] QuestionWriteModel questionWriteModel)
        {
            var command = new CreateQuestionCommand(
                questionWriteModel.QuestionText,
                questionWriteModel.Difficulty,
                questionWriteModel.Answers,
                questionWriteModel.CategoryId
            );

            _quizzFacade.AddQuestion(command);

            return CreatedAtAction(null, null);
        }

        [HttpPatch]
        [Route("{questionId}/approve")]
        public IActionResult Approve(Guid questionId)
        {
            var command = new ApproveQuestionCommand(questionId);
            _quizzFacade.ApproveQuestion(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{questionId}/reject")]
        public IActionResult Reject(Guid questionId, [FromBody] string reason)
        {
            var command = new RejectQuestionCommand(questionId, reason);
            _quizzFacade.RejectQuestion(command);

            return NoContent();
        }

        [HttpPut]
        [Route("{questionId}")]
        public IActionResult Update(Guid questionId, [FromBody] QuestionWriteModel questionWriteModel)
        {
            var command = new UpdateQuestionCommand(
                questionId,
                questionWriteModel.QuestionText,
                questionWriteModel.Difficulty,
                questionWriteModel.Answers,
                questionWriteModel.CategoryId
            );
            _quizzFacade.EditQuestion(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("{questionId}")]
        public IActionResult Delete(Guid questionId)
        {
            var command = new DeleteQuestionCommand(questionId);
            _quizzFacade.DeleteQuestion(command);

            return NoContent();
        }

        [HttpGet]
        [Route("{questionId}")]
        public IActionResult Get(Guid questionId)
        {
            var query = new GetQuestionQuery(questionId);

            var question = _quizzFacade.GetQuestion(query);

            return Ok(question);
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            var query = new ListQuestionsQuery();
            var questions = _quizzFacade.GetQuestions(query);
            return Ok(questions);
        }
    }
}