using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gada.Domain;
using Gada.Accounts.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Gada.Accounts
{
    public interface IAccountsContext : IDisposable
    {
        IRepository<User> AccountsRepository { get; }

        Database Db { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbEntityEntry Entry(object entity);

        void Save();
    }
}
