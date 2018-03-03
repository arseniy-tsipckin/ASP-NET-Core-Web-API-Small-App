using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public abstract class  BaseRepository<TEntity,IEntity>:IRepository<IEntity>
        where TEntity:AbstractModel, IEntity
        where IEntity:IModel
        
    {
        protected readonly VendorsDbContext _context;
        protected readonly DbSet<TEntity> _entities;



        public BaseRepository(VendorsDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual IEntity Add(IEntity entity)
        {
            var newEntity=_entities.Add(MapFromProxyToEntity(entity));
            _context.SaveChanges();
            return newEntity.Entity;
        }

        public virtual IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public virtual long Count()
        {
            return _entities.Count();
        }
        public virtual long Count(Expression<Func<IEntity, bool>> predicate)
        {
            return _entities.Count(predicate);
        }
        public virtual IEnumerable<IEntity> Get(Expression<Func<IEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }
        
        public virtual IEntity Get(long id)
        {
            return  _entities.FirstOrDefault(ent => ent.Id == id); 
        }
        public virtual void Remove(long id)
        {
            var entity = GetEntity(id);
             _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<long> ids)
        {
            var entities = GetEntities(ids);
            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }

        
        public virtual void Update(IEntity entity)
        {
            var oldEntity = GetEntity(entity.Id);
            _context.Entry(oldEntity).State = EntityState.Unchanged;
            oldEntity = MapFromProxyToEntity(entity, oldEntity, opts => opts.ConfigureMap()
            .ForMember(x => x.Id, opt => opt.Ignore()));
            _context.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<IEntity> entities)
        {
            
            _entities.UpdateRange(MapFromProxyToEntityRange(entities));
            _context.SaveChanges();
        }
        public virtual IEntity GetSingleOrDefault(Expression<Func<IEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }
        public virtual IEnumerable<IEntity> GetAll()
        {
            return GetAllEntities();
        }
        public abstract IEnumerable<IEntity> Search(string keyword);


        protected virtual TEntity GetEntity(long id)
        {
            return _entities.FirstOrDefault(ent => ent.Id == id);
        }
        protected virtual IEnumerable<TEntity> GetAllEntities()
        {
            return _entities;
        }
        protected virtual IEnumerable<TEntity> GetEntities(IEnumerable<long> ids)
        {
            return _entities.Where(ent =>(ids).Contains(ent.Id));
        }
        protected virtual TEntity GetAsNoTracking(long id)
        {
            return _entities.AsNoTracking().FirstOrDefault(ent => ent.Id == id);
        }


        protected TEntity MapFromProxyToEntity(object iEntity,TEntity entity, Action<IMappingOperationOptions<object, TEntity>> opts)
        {
            return Mapper.Map(iEntity, entity,opts);
        }
        protected TEntity MapFromProxyToEntity(IEntity iEntity)
        {
            return Mapper.Map<IEntity, TEntity>(iEntity);
        }
        protected IEntity MapFromEntityToProxy(TEntity entity)
        {
            return Mapper.Map<TEntity, IEntity>(entity);
        }
        protected IEnumerable<TEntity> MapFromProxyToEntityRange(IEnumerable<IEntity> iEntities)
        {
            return Mapper.Map<IEnumerable<IEntity>, IEnumerable<TEntity>>(iEntities);
        }
        protected IEnumerable<IEntity> MapFromEntityToProxyRange(IEnumerable<TEntity> entities)
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<IEntity>>(entities);
        }


    }
}
