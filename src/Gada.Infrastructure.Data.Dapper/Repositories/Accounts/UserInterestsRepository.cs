using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gada.Accounts.Entities;
using Gada.Accounts.Repositories;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Gada.Infrastructure.Data.Dapper.Queries;
using Gada.Interests.Repositories;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Accounts
{
    public class InterestsRepository : IInterestsRepository<Interest>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public async Task<IEnumerable<Interest>> GetUserInterests(Guid userId)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Interest>(InterestQueries.GetUserInterests, new { UserId = userId });
            }
        }

        public async Task<IEnumerable<Interest>> Find(string title)
        {
            using(IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Interest>(InterestQueries.FindByTitle, new { Title = title });
            }
        }
    }
}
