using Microsoft.EntityFrameworkCore;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly EfDbContext _context;
        private readonly DbSet<Question> _questions;

        public QuestionRepository(EfDbContext context) : base(context)
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

        protected override IQueryable<Question> QueryWithIncludes()
        {
            return _questions.Include(q => q.Category);
        }
    }
}