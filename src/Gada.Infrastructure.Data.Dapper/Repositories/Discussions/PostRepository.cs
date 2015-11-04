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
    public class PostRepository : IPostRepository<Post>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["GadaContext"].ConnectionString);
            }
        }

        public async Task<IEnumerable<Post>> GetLatest()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Post, User, Discussion, Post>(PostQueries.GetLatest,
                    (post, user, discussion) =>
                    {
                        post.SetPostedBy(user);
                        post.SetDiscussion(discussion);
                        return post;
                    }, splitOn: "PostedBy_Id,Discussion_Id");
            }
        }

        public Post FindById(Guid id)
        {
            return null;
        }

        public Post Get(Guid id)
        {
            Post post = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var posts = connection.Query<Post>(PostQueries.Get, new { Id = id });

                post = posts.FirstOrDefault();
            }

            return post;
        }
    }
}
