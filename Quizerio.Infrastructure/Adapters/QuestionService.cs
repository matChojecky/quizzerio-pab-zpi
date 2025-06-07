using Application;
using Application.Quiz;
using Application.Quiz.Commands;
using Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Adapters
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(
            IUnitOfWork unitOfWork,
            IQuestionRepository questionRepository,
            IQuestionCategoryRepository questionCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
            _questionCategoryRepository = questionCategoryRepository;
        }


        public void ChangeQuestionStatus(ChangeQuestionStatusCommand command)
        {
            _questionRepository.UpdateQuestionStatus(command.Id, command.Status);
            _unitOfWork.Commit();
        }

        public void AddQuestion(CreateQuestionCommand command)
        {
            List<Answer> answers = command.Answers.Select(a => new Answer(a.Text, a.IsCorrect)).ToList();
            QuestionCategory category = _questionCategoryRepository.GetById(command.CategoryId);

            var question = new Question(
                Guid.NewGuid(),
                command.QuestionText,
                command.Difficulty,
                QuestionStatus.Pending,
                answers,
                category
            );

            _questionRepository.Add(question);
            _unitOfWork.Commit();
        }

        public void DeleteQuestion(DeleteQuestionCommand command)
        {
            _questionRepository.Delete(command.Id);
            _unitOfWork.Commit();
        }

        public void UpdateQuestion(UpdateQuestionCommand updateQuestion)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(GetQuestionQuery query)
        {
            return _questionRepository.GetById(query.Id);
        }

        public List<Question> GetQuestions(ListQuestionsQuery query)
        {
            return _questionRepository.GetAll();
        }
    }
}