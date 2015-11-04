using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gada.Accounts.Repositories;
using Gada.Accounts.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Gada.Infrastructure.Data.Dapper.Queries;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Accounts
{
    public class AccountsRepository : IAccountsRepository<User>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public User GetByEmail(string email)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    return connection.Query<User>(UserQueries.FindByEmail, new { Email = email }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetById(Guid id)
        {
            User user = null;
            using(IDbConnection connection = Connection)
            {
                connection.Open();
                var users = connection.Query<User>(UserQueries.Get, new { Id = id });

                user = users.FirstOrDefault();
            }

            return user;
        }

        public async Task<int> GetCountOfUsernames(string query)
        {
            IEnumerable<int> count = new List<int>();
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                count = await connection.QueryAsync<int>(UserQueries.GetCountOfUsernames, new { Username = query });
                return count.SingleOrDefault();
            }
        }
    }
}
