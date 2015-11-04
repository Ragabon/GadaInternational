using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;

namespace Gada.Api.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        private readonly IDiscussionRepository<Discussion> _discussionRepository;
        private readonly IPostRepository<Post> _postRepository; 

        public HomeController(IDiscussionRepository<Discussion> discussionRepository,
            IPostRepository<Post> postRepository )
        {
            _discussionRepository = discussionRepository;
            _postRepository = postRepository;

            Mapper.AddProfile<HomeMappingProfile>();
        }

        // GET api/<controller>
        [Route("newsfeed")]
        [HttpGet]
        public async Task<IHttpActionResult> GetNewsFeed()
        {
            var latestDiscussions = await _discussionRepository.GetLatest();
            var latestPosts = await _postRepository.GetLatest();

            var newsFeed =
                Mapper.Map<IEnumerable<Discussion>, IEnumerable<NewsFeedModel>>(latestDiscussions)
                    .Concat(Mapper.Map<IEnumerable<Post>, IEnumerable<NewsFeedModel>>(latestPosts));
            
            return Ok(newsFeed.OrderByDescending(x => x.CreatedDateTime).ToList());
        }
    }
}
