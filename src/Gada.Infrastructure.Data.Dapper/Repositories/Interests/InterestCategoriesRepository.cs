using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gada.Interests.Repositories;
using Gada.Interests.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Gada.Infrastructure.Data.Dapper.Queries;
using Dapper;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Interests
{
    public class InterestCategoriesRepository : IInterestCategoriesRepository<InterestCategory>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public InterestCategory Get(Guid id)
        {
            IEnumerable<InterestCategory> results = new List<InterestCategory>();
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                results = connection.Query<InterestCategory>(InterestQueries.GetCategory, new { Id = id });
            }
            return results.SingleOrDefault();
        }

        public async Task<IEnumerable<InterestCategory>> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<InterestCategory>(InterestQueries.GetAllCategories);
            }
        }

        public async Task<IEnumerable<InterestCategory>> Find(string query)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<InterestCategory>(InterestQueries.FindCategory, new { CategoryName = query });
            }
        }
    }
}
