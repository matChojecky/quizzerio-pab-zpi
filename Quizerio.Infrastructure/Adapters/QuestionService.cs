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
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
        }


        public void ChangeQuestionStatus(ChangeQuestionStatusCommand command)
        {
            _questionRepository.UpdateQuestionStatus(command.Id, command.Status);
            _unitOfWork.Commit();
        }

        public void AddQuestion(CreateQuestionCommand command)
        {
            List<Answer> answers = command.Answers.Select(a => new Answer(a.Text, a.IsCorrect)).ToList();

            var question = new Question(
                Guid.NewGuid(),
                command.QuestionText,
                command.Difficulty,
                QuestionStatus.Pending,
                answers,
                new QuestionCategory()
            );

            _questionRepository.AddQuestion(question);
            _unitOfWork.Commit();
        }

        public void DeleteQuestion(DeleteQuestionCommand command)
        {
            _questionRepository.DeleteQuestion(command.Id);
            _unitOfWork.Commit();
        }

        public void UpdateQuestion(UpdateQuestionCommand updateQuestion)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(GetQuestionQuery query)
        {
            return _questionRepository.GetQuestion(query.Id);
        }

        public List<Question> GetQuestions(ListQuestionsQuery query)
        {
            return _questionRepository.GetQuestions();
        }
    }
}