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
    public class UsersRepository : IUsersRepository<User>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public User Get(string query)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    return connection.Query<User>(UserQueries.FindByEmail, new { Email = query }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public User GetById(Guid id)
        {
            using(IDbConnection connection = Connection)
            {
                connection.Open();
                return connection.QueryAsync<User>(UserQueries.FindById, new { Id = id }).Result.SingleOrDefault();
            }
        }

       
    }
}
