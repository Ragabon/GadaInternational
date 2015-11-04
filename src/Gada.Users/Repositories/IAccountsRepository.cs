using Gada.Domain;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Gada.Accounts.Repositories
{
    public interface IAccountsRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T GetByEmail(string email);
        T GetById(Guid id);
        Task<int> GetCountOfUsernames(string query);
    }
}