using Gada.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gada.Accounts.Repositories
{
    public interface IUserSkillsRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        //T Get(Guid id);

        Task<IEnumerable<T>> GetUserSkills(Guid userId);
    }
}