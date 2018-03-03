using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : IModel
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(long id);
        void RemoveRange(IEnumerable<long> ids);

        long Count();
        long Count(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Search(string keyword);
    }
}
