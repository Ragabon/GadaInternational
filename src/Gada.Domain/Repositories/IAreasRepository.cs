using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Gada.Domain;

namespace Gada.Discussions.Repositories
{
    public interface IAreasRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        Task<IEnumerable<T>> GetAll();

        T Get(string query);
    }
}
