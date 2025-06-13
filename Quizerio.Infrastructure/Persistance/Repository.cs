using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Quizerio.Domain.Common;

namespace Quizerio.Infrastructure.Persistance
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository(EfDbContext dbContext)
        {
            _db = dbContext;
            enitities = dbContext.Set<TEntity>();
        }

        private EfDbContext _db { get; }
        private DbSet<TEntity> enitities { get; }

        public void Add(TEntity entity)
        {
            enitities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            enitities.Update(entity);
        }

        public TEntity GetById(Guid entityId)
        {
            var entity = enitities.Find(entityId);

            if (entity == null) throw new KeyNotFoundException("Entity not found");

            return entity;
        }

        public List<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicates = null)
        {
            var query = QueryWithIncludes();
            if (predicates != null && predicates.Any())
            {
                query = predicates.Aggregate(query, (current, predicate) => current.Where(predicate));
            }
            
            return query.ToList();
        }

        public void Delete(Guid entityId)
        {
            var entity = enitities.Find(entityId);

            if (entity == null) return;

            enitities.Remove(entity);
        }

        protected virtual IQueryable<TEntity> QueryWithIncludes()
        {
            return enitities;
        }
    }
}