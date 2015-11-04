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
    public class DiscussionRepository : IDiscussionRepository<Discussion>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public Discussion FindById(Guid id)
        {
            Discussion discussion = null;
            List<Post> posts = new List<Post>();

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var discussions = connection.Query<Discussion, User, string, Post, User, Discussion>(DiscussionQueries.FindById, 
                    (discussiion, user, interests, post, postedBy) => 
                    {
                        discussiion.SetCreatedBy(user);
                        if (interests != String.Empty)
                        {
                            foreach(string interest in interests.Split(';'))
                                discussiion.AddInterest(Interest.CreateInterest(interest));
                        }
                        if (post != null)
                        {
                            post.SetPostedBy(postedBy);
                            posts.Add(post);
                        }
                        
                        return discussiion;
                    }, 
                    new { ID = id },
                    splitOn: "CreatedBy_Id,Interests,Discussion_Id,PostedBy_Id");

                discussion = discussions.FirstOrDefault();

                foreach (var post in posts)
                {
                    discussion.AddPost(post);
                }
            }

            return discussion;
        }

        public Discussion Get(Guid id)
        {
            Discussion discussion = null;
            
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var discussions = connection.Query<Discussion>(DiscussionQueries.Get, new { Id = id });

                discussion = discussions.FirstOrDefault();
            }

            return discussion;
        }

        public async Task<IEnumerable<Discussion>> GetAll()
        {
            //IEnumerable<Discussion> discussions = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                //discussions = connection.Query<Discussion>(DiscussionQueries.GetAll);
                return await connection.QueryAsync<Discussion>(DiscussionQueries.GetAll);
            }

            //return discussions;
        }

        public async Task<IEnumerable<Discussion>> GetList()
        {
            //IEnumerable<Discussion> discussions = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Discussion, User, string, Discussion>(DiscussionQueries.GetList,
                    (discussiion, user, interests) => 
                    {
                        discussiion.SetCreatedBy(user);
                        if (interests != String.Empty && interests != null)
                        {
                            foreach(string interest in interests.Split(';'))
                                discussiion.AddInterest(Interest.CreateInterest(interest));
                        }
                        return discussiion;
                    }, splitOn: "CreatedBy_Id,Interests");
            }

            //return discussions;
        }

        public async Task<IEnumerable<Discussion>> GetListByArea(Guid area)
        {
            //IEnumerable<Discussion> discussions = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Discussion, User, string, Discussion>(DiscussionQueries.GetListByArea,
                    (discussiion, user, interests) =>
                    {
                        discussiion.SetCreatedBy(user);
                        if (interests != String.Empty && interests != null)
                        {
                            foreach (string interest in interests.Split(';'))
                                discussiion.AddInterest(Interest.CreateInterest(interest));
                        }
                        return discussiion;
                    }, new { Area = area }, splitOn: "CreatedBy_Id,Interests");
            }

            //return discussions;
        }

        public async Task<IEnumerable<Discussion>> GetRelated(Guid id)
        {
            //IEnumerable<Discussion> discussions = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Discussion, User, Discussion>(DiscussionQueries.GetRelated,
                    (discussiion, user) =>
                    {
                        discussiion.SetCreatedBy(user);
                        return discussiion;
                    }, new { Id = id }, splitOn: "CreatedBy_Id");
            }

            //return discussions;
        }
        
        public async Task<IEnumerable<Discussion>> GetLatest()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Discussion, User, Discussion>(DiscussionQueries.GetLatest,
                    (discussiion, user) =>
                    {
                        discussiion.SetCreatedBy(user);
                        return discussiion;
                    }, splitOn: "CreatedBy_Id");
            }
        }
    }
}
