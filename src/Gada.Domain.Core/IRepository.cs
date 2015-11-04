using System.Linq;

namespace Gada.Domain
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class, IEntity
    {
        IQueryable<T> AsQueryable();

        void Add(T entity);

        void Remove(T entity);

        void Attach(T entity);
    }
}
