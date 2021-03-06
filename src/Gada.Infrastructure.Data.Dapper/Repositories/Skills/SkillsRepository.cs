﻿using Gada.Accounts.Repositories;
using Gada.Infrastructure.Data.Dapper.Queries;
using Gada.Skills.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gada.Skills.Repositories;

namespace Gada.Infrastructure.Data.Dapper.Repositories.Skills
{
    public class SkillsRepository : ISkillsRepository<Skill>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public Skill Get(Guid id)
        {
            IEnumerable<Skill> results = new List<Skill>();
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                results = connection.Query<Skill>(SkillQueries.Get, new { Id = id });
            }
            return results.SingleOrDefault();
        }
        public async Task<IEnumerable<Skill>> GetAll()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Skill>(SkillQueries.GetAll);
            }
        }

        public async Task<IEnumerable<Skill>> Find(string query)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Skill>(SkillQueries.FindByTitle, new { Title = query });
            }
        }

        public IEnumerable<Skill> Get(string[] titles)
        {
            //string query = "";

            //foreach(string title in titles)
            //{
            //    query += query == "" ? String.Format("{0}", title) : String.Format(",{0}", title);
            //}

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return connection.Query<Skill>(SkillQueries.GetByTitles, new { Titles = titles });
            }
        }

        public async Task<IEnumerable<Skill>> GetUserSkills(Guid userId)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Skill>(SkillQueries.GetUserSkills, new { UserId = userId });
            }
        }
    }
}
