using Dapper;
using Gada.Infrastructure.Data.Dapper.Queries;
using Gada.Skills.Entities;
using Gada.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Skills
{
    public class SkillCategoriesRepository : ISkillCategoriesRepository<SkillCategory>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public SkillCategory Get(Guid id)
        {
            IEnumerable<SkillCategory> results = new List<SkillCategory>();
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                results = connection.Query<SkillCategory>(SkillQueries.GetCategory, new { Id = id });
            }
            return results.SingleOrDefault();
        }

        public async Task<IEnumerable<SkillCategory>> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<SkillCategory>(SkillQueries.GetAllCategories);
            }
        }

        public async Task<IEnumerable<SkillCategory>> Find(string query)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<SkillCategory>(SkillQueries.FindCategory, new { CategoryName = query });
            }
        }
    }
}