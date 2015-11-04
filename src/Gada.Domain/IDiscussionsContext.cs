using System.Data.Entity.Infrastructure;
using Gada.Discussions.Entities;
using System;
using System.Data.Entity;
using Gada.Domain;

namespace Gada.Discussions
{
    public interface IDiscussionsContext : IDisposable
    {
        IRepository<Discussion> DiscussionRepository { get; }

        IRepository<Post> PostRepository { get; }

        IRepository<User> UsersRepository { get; }

        Database Db { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        
        DbEntityEntry Entry(object entity);

        void Save();
    }
}
