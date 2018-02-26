using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.Repositories
{
    public interface IRepository<IEntity> where IEntity : IModel
    {
        IEntity Add(IEntity entity);
        IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities);

        void Update(IEntity entity);
        void UpdateRange(IEnumerable<IEntity> entities);

        void Remove(long id);
        void RemoveRange(IEnumerable<long> ids);

        long Count();
        long Count(Expression<Func<IEntity, bool>> predicate);

        IEnumerable<IEntity> Get(Expression<Func<IEntity, bool>> predicate);
        IEntity GetSingleOrDefault(Expression<Func<IEntity, bool>> predicate);
        IEntity Get(long id);
        IEnumerable<IEntity> GetAll();
    }
}
