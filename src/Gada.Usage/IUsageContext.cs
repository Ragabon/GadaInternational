using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Gada.Domain;
using Gada.Usage.Entities;

namespace Gada.Usage
{
    public interface IUsageContext : IDisposable
    {
        IRepository<Log> LogRepository { get; }

        IRepository<LogType> LogTypeRepository { get; }

        Database Db { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbEntityEntry Entry(object entity);

        void Save();
    }
}
