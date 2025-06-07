using Quizerio.Application;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.DTO;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Adapters
{
    public class QuizzFacade : IQuizzFacade
    {
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionCategoryRepository _questionCategoryRepository;

        public QuizzFacade(
            IUnitOfWork unitOfWork,
            IQuestionService questionService,
            IQuestionCategoryRepository questionCategoryRepository)
        {
            _questionService = questionService;
            _questionCategoryRepository = questionCategoryRepository;
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

        public void AddQuestionCategory(AddQuestionCategoryCommand command)
        {
            var category = new QuestionCategory(
                command.Name,
                Guid.NewGuid()
            );
            
            _questionCategoryRepository.Add(category);
            _unitOfWork.Commit();
        }

        public List<QuestionCategory> GetQuestionCategories()
        {
            return _questionCategoryRepository.GetAll();
        }
    }
}