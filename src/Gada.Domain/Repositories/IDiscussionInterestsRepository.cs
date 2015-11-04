using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Gada.Domain;

namespace Gada.Discussions.Repositories
{
    public interface IDiscussionInterestsRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Find(string query);

        IEnumerable<T> Get(string[] titles);
    }
}
