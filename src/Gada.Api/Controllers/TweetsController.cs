using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;
using Gada.Twitter.Entities;
using Gada.Twitter.Services;

namespace Gada.Api.Controllers
{
    [RoutePrefix("api/tweets")]
    public class TweetsController : ApiController
    {
        private readonly ITwitterService _twitterService;

        public TweetsController(ITwitterService twitterService)
        {
            _twitterService = twitterService;

            Mapper.AddProfile<TweetsMappingProfile>();
        }

        [Route()]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var tweets = _twitterService.GetLatestTweets(10);

            return Ok(Mapper.Map<IEnumerable<Tweet>, IEnumerable<TweetsModel>>(tweets));
        }
    }
}
