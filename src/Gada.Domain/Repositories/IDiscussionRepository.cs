using System.Data;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Gada.Domain;

namespace Gada.Discussions.Repositories
{
    public interface IDiscussionRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T FindById(Guid id);
        
        T Get(Guid id);
        
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetList();

        Task<IEnumerable<T>> GetListByArea(Guid area);

        Task<IEnumerable<T>> GetRelated(Guid id);

        Task<IEnumerable<T>> GetLatest();
    }
}
