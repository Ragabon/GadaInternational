using Gada.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gada.Skills.Repositories
{
    public interface ISkillsRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T Get(Guid id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Find(string query);

    }
}