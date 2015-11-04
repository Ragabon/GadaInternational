using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Gada.Domain;

namespace Gada.Infrastructure.Data.EntityFramework
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> _dbSet;

        public Repository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public IDbConnection Connection
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }
    }
}
