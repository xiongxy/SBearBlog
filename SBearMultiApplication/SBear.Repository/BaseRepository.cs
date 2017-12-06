using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SBear.Entities;

namespace SBear.Repository
{
    public class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity
    {
        private readonly DataContext _dataContext;
        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var v = _dataContext.Set<TEntity>().FirstOrDefault(predicate);
                _dataContext.Remove(v);
                _dataContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Get(TPrimaryKey id)
        {
            return _dataContext.Set<TEntity>().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public IEnumerable<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include)
        {
            return _dataContext.Set<TEntity>().Where(predicate).Include(include).ToList();
        }
        public IEnumerable<TEntity> GetListAll()
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
            _dataContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 根据主键构建判断表达式
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
            );
            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        public int GetTotalCount(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().Count(predicate);
        }

        public IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order)
        {
            var result = _dataContext.Set<TEntity>().Where(where).OrderBy(order).Take(pageSize).Skip(startPage * pageSize).ToList();
            rowCount = result.Count();
            return result.AsQueryable();
        }
    }

    public class BaseRepository<TEntity> : BaseRepository<TEntity, long> where TEntity : BaseEntity
    {
        public BaseRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }


}
