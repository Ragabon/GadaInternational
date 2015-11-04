using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Gada.Domain;

namespace Gada.Usage.Repositories
{
    public interface ILogRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        Task<IEnumerable<T>> GetByUserAndType(Guid userId, Guid usageTypeId);
    }
}
