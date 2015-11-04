using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gada.Infrastructure.Data.Dapper.Queries;
using Gada.Usage.Entities;
using Gada.Usage.Repositories;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Usage
{
    public class LogRepository : ILogRepository<Log>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public async Task<IEnumerable<Log>> GetByUserAndType(Guid userId, Guid usageTypeId)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Log>(UsageQueries.FindByUserIdAndTypeId, new { UserId = userId, TypeId = usageTypeId });
            }
        }
    }
}
