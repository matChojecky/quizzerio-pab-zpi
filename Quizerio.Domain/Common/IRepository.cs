using System.Linq.Expressions;

namespace Quizerio.Domain.Common
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        TEntity GetById(Guid id);

        List<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicate = null);

        void Delete(Guid id);
    }
}