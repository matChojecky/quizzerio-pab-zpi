using Microsoft.EntityFrameworkCore;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly EfDbContext _context;
        private readonly DbSet<Question> _questions;

        public QuestionRepository(EfDbContext context)
        {
            _context = context;
            _questions = context.Set<Question>();
        }

        public void UpdateQuestionStatus(Guid id, QuestionStatus status)
        {
            _questions
                .Where(q => q.Id == id)
                .ExecuteUpdate(q =>
                    q.SetProperty(it => it.Status, status)
                );
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }

        public void UpdateQuestion(Question question)
        {
            _questions.Update(question);
        }

        public Question GetQuestion(Guid questionId)
        {
            var question = _questions.FirstOrDefault(q => q.Id == questionId);

            if (question == null) throw new KeyNotFoundException($"Question with id {questionId} not found");

            return question;
        }

        public List<Question> GetQuestions()
        {
            return _questions.ToList();
        }

        public void DeleteQuestion(Guid questionId)
        {
            var question = _questions.FirstOrDefault(q => q.Id == questionId);

            if (question == null) return;

            _questions.Remove(question);
        }
    }
}