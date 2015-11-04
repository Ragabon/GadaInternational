using System;
using System.Data;
using System.Threading.Tasks;
using Gada.Domain;

namespace Gada.Discussions.Repositories
{
    public interface IUsersRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T Get(string query);

        T GetById(Guid id);


        //Task<Profile> GetProfile(Guid id);
    }
}
