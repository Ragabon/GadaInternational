using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Gada.Discussions.Repositories;
using Gada.Discussions.Entities;
using Gada.Infrastructure.Data.Dapper.Queries;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Discussions
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

        public async Task<IEnumerable<Interest>> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Interest>(InterestQueries.GetAll);
            }
        }

        public async Task<IEnumerable<Interest>> Find(string query)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Interest>(InterestQueries.FindByTitle, new { Title = query });
            }
        }

        public IEnumerable<Interest> Get(string[] titles)
        {
            //string query = "";

            //foreach(string title in titles)
            //{
            //    query += query == "" ? String.Format("{0}", title) : String.Format(",{0}", title);
            //}

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return connection.Query<Interest>(InterestQueries.GetByTitles, new { Titles = titles });
            }
        }
    }
}
