using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;
using Gada.Infrastructure.Data.Dapper.Queries;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Discussions
{
    public class AreasRepository : IAreasRepository<Area>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public async Task<IEnumerable<Area>> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Area>(AreaQueries.GetAll);
            }
        }
        public Area Get(string query)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return connection.Query<Area>(AreaQueries.GetById, new { Id = query }).SingleOrDefault();
            }
        }
    }
}
