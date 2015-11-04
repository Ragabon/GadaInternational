using Gada.Infrastructure.Data.Dapper.Queries;
using Gada.Interests.Entities;
using Gada.Interests.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Interests
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

        public Interest Get(Guid id)
        {
            IEnumerable<Interest> results = new List<Interest>();
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                results = connection.Query<Interest>(InterestQueries.Get, new { Id = id });
            }
            return results.SingleOrDefault();
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

        public async Task<IEnumerable<Interest>> GetUserInterests(Guid userId)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Interest>(InterestQueries.GetUserInterests, new { UserId = userId });
            }
        }
    }
}
