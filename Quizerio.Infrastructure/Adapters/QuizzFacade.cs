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


        public void ApproveQuestion(ApproveQuestionCommand command)
        {
            _questionService.ChangeQuestionStatus(command);
            _unitOfWork.Commit();
        }

        public void RejectQuestion(RejectQuestionCommand command)
        {
            _questionService.ChangeQuestionStatus(command);
            // TODO: send email to submitting user
            
            _unitOfWork.Commit();
        }

        public Question GetQuestion(GetQuestionQuery query)
        {
            return _questionService.GetQuestion(query);
        }

        public List<Question> GetQuestions(ListQuestionsQuery query)
        {
            return _questionService.GetQuestions(query);
        }

        public List<Question> GetQuestions()
        {
            return _questionService.GetQuestions(new ListQuestionsQuery());
        }

        public void AddQuestion(CreateQuestionCommand command)
        {
            _questionService.AddQuestion(command);
            _unitOfWork.Commit();
        }


        public void DeleteQuestion(DeleteQuestionCommand command)
        {
            _questionService.DeleteQuestion(command);
            
        }

        public void EditQuestion(UpdateQuestionCommand command)
        {
            _questionService.UpdateQuestion(command);
            
            _unitOfWork.Commit();
        }
    }
}