using System.Data;

namespace Gada.Domain
{
    public interface IReadOnlyRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }
    }
}
