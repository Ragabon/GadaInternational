using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Gada.Domain;

namespace Gada.Discussions.Repositories
{
    public interface IPostRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T FindById(Guid id);
        
        T Get(Guid id);
        
        Task<IEnumerable<T>> GetLatest();
    }
}
