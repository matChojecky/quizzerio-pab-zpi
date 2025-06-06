using Quizerio.Domain.Question.Ports;

namespace Quizerio.Domain.Quizz
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public void ChangeQuestionStatus(Guid id, QuestionStatus status)
        {
            _repository.UpdateQuestionStatus(id, status);
        }

        public void AddQuestion(QuestionWriteModel questionDto)
        {
            Question question = new Question(
                Guid.NewGuid(),
                questionDto.QuestionText,
                questionDto.Difficulty,
                QuestionStatus.Pending,
                questionDto.Answers
            );

            _repository.AddQuestion(question);
        }

        public void AddQuestions(List<QuestionWriteModel> questions)
        {
            // Let's assume this loops and creates transaction
            foreach (var questionWriteModel in questions)
            {
                AddQuestion(questionWriteModel);
            }
        }

        public void DeleteQuestion(Guid questionId)
        {
            _repository.DeleteQuestion(questionId);
        }

        public void EditQuestion(Guid id, QuestionWriteModel question)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }
    }
}