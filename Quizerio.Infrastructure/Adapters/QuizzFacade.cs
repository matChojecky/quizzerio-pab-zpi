using Application;
using Application.Quiz;
using Application.Quiz.Commands;
using Application.Quiz.DTO;
using Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Adapters
{
    public class QuizzFacade : IQuizzFacade
    {
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;

        public QuizzFacade(
            IQuestionService questionService,
            IUnitOfWork unitOfWork
        )
        {
            _questionService = questionService;
            _unitOfWork = unitOfWork;
        }


        public void ApproveQuestion(Guid questionId)
        {
            var command = new ChangeQuestionStatusCommand(questionId, QuestionStatus.Approved);

            _questionService.ChangeQuestionStatus(command);
            _unitOfWork.Commit();
        }

        public void RejectQuestion(Guid questionId, string reason)
        {
            var command = new ChangeQuestionStatusCommand(questionId, QuestionStatus.Rejected);
            _questionService.ChangeQuestionStatus(command); // TODO: send email to submitting user
            
            _unitOfWork.Commit();
        }

        public Question GetQuestion(Guid questionId)
        {
            var query = new GetQuestionQuery();
            return _questionService.GetQuestion(query);
        }

        public List<Question> GetQuestions()
        {
            return _questionService.GetQuestions(new ListQuestionsQuery());
        }

        public void AddQuestion(QuestionWriteModel question)
        {
            _questionService.AddQuestion(question);
            _unitOfWork.Commit();
        }


        public void DeleteQuestion(Guid questionId)
        {
            _questionService.DeleteQuestion(new DeleteQuestionCommand(questionId));
            
        }

        public void EditQuestion(Guid questionId, QuestionWriteModel question)
        {
            throw new NotImplementedException();
        }
    }
}