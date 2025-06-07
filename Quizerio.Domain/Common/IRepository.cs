using System;
using System.Collections.Generic;

namespace Quizerio.Domain.Common
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        TEntity GetById(Guid id);

        List<TEntity> GetAll();

        void Delete(Guid id);
    }
}