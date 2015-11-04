using Gada.Domain;
using Gada.Interests.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gada.Interests
{
    public interface IInterestsContext : IDisposable 
    {
        IRepository<Interest> InterestRepository { get;  }

        IRepository<InterestCategory> InterestCategoryRepository { get; }

        Database Db { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbEntityEntry Entry(object entity);

        void Save();
    }
}
