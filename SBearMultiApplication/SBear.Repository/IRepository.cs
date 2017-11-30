using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SBear.Entities;

namespace SBear.Repository
{
    public interface IRepository<TEntity, in TPrimaryKey> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetListAll();
        IEnumerable<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(TPrimaryKey id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(TPrimaryKey id);
    }
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : BaseEntity
    {

    }
}
