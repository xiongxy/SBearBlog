using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SBear.Entities;
using System.Linq;

namespace SBear.Repository
{
    public interface IRepository<TEntity, in TPrimaryKey> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include);
        TEntity Get(TPrimaryKey id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(Expression<Func<TEntity, bool>> predicate);
        bool Delete(TPrimaryKey id);
        int GetTotalCount(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order);
    }
    public interface IRepository<TEntity> : IRepository<TEntity, long> where TEntity : BaseEntity
    {

    }
}
