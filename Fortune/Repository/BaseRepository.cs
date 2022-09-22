using Fortune.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fortune.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        TEntity Get(Guid Id);
        TEntity Get(int Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entites);
        void Delete(TEntity entity);
        void Delete(Guid Id);
        void Delete(int Id);
        bool Save();
        void RemoveRange(IEnumerable<TEntity> entites);
    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<TEntity> _dbSet;


        public BaseRepository(ApplicationDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Database Bulunamadı!");

            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();

        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

        }

        public virtual void UpdateRange(IEnumerable<TEntity> entites)
        {
            _dbContext.UpdateRange(entites);

        }

        public virtual void Delete(TEntity entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public virtual void Delete(Guid Id)
        {
            var entity = Get(Id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
        public virtual void Delete(int Id)
        {
            var entity = Get(Id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> result = predicate == null ? _dbSet : _dbSet.Where(predicate);
            return result;
        }

        public virtual TEntity Get(Guid Id)
        {
            return _dbSet.Find(Id);
        }
        public virtual TEntity Get(int Id)
        {
            return _dbSet.Find(Id);
        }

        public bool Save()
        {
            // Etkilenen kayıt sayısına göre
            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public void RemoveRange(IEnumerable<TEntity> entites)
        {
            _dbContext.RemoveRange(entites);
        }
    }
}
