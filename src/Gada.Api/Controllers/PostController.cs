using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;
using Gada.Discussions;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Gada.Usage;
using Gada.Usage.Entities;
using Gada.Usage.Repositories;
using Newtonsoft.Json;

namespace Gada.Api.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostController : ApiController
    {
        private readonly IDiscussionsContext _context;
        private readonly IUsageContext _usageContext;
        private readonly IPostRepository<Post> _postRepository;
        private readonly IUsersRepository<User> _userRepository;
        private readonly IDiscussionRepository<Discussion> _discussionRepository;
        private readonly ILogRepository<Log> _logRepository;
        private readonly ILogTypeRepository<LogType> _logTypeRepository;

        public PostController(IDiscussionsContext context,
            IUsageContext usageContext,
            IPostRepository<Post> postRepository,
            IUsersRepository<User> userRepository,
            IDiscussionRepository<Discussion> discussionRepository,
            ILogRepository<Log> logRepository,
            ILogTypeRepository<LogType> logTypeRepository)
        {
            _context = context;
            _usageContext = usageContext;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _discussionRepository = discussionRepository;
            _logRepository = logRepository;
            _logTypeRepository = logTypeRepository;

            Mapper.AddProfile<PostsMappingProfile>();
        }

        // GET api/<controller>
        [Route("latest")]
        [HttpGet]
        public async Task<IHttpActionResult> Get() //<IEnumerable<DiscussionListModel>>
        {
            var posts = await _postRepository.GetLatest();

            return Ok(Mapper.Map<IEnumerable<Post>, IEnumerable<LatestPostModel>>(posts));
        }

        [Route("add")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(CreatePostModel postModel)
        {
            try
            {
                var user = _userRepository.GetById(postModel.UserId);

                var post = Discussions.Entities.Post.CreatePost(postModel.Content, user);

                var discussion = _discussionRepository.Get(postModel.DiscussionId);

                discussion.AddPost(post);

                _context.DiscussionRepository.Add(discussion);
                _context.Entry(discussion).State = EntityState.Modified;
                
                //_context.Entry(discussion.Posts[0].PostedBy).State = EntityState.Unchanged;
                _context.Save();

                PostDetailModel pdm = new PostDetailModel 
                { 
                    Id = post.Id,
                    PostedBy = user.Username,
                    Posted = post.PostedOn.ToShortDateString(),
                    Post = post.Content,
                    Votes = 0
                };

               // return Ok(post);
                return Ok(pdm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("{id:guid}/voteup")]
        [HttpGet]
        public async Task<IHttpActionResult> VoteUp(Guid id)
        {
            var post = _postRepository.Get(id);
            post.VoteUp();

            _context.PostRepository.Add(post);
            _context.Entry(post).State = EntityState.Modified;
            _context.Save();

            return Ok();
        }

        [Route("voteup")]
        [HttpPost]
        public async Task<IHttpActionResult> VoteUp(VoteModel vote)
        {
            var logType = _logTypeRepository.GetLogTypeByName("PostVote");

            var usage = await _logRepository.GetByUserAndType(vote.UserId, logType.Id);

            var search = String.Format(@"""ArtifactId"":""{0}""", vote.ArtifactId);

            if (usage.Any(x => x.LogData.Contains(search)))
                return InternalServerError(new Exception("You have already voted on this post"));

            var post = _postRepository.Get(vote.ArtifactId);
            post.VoteUp();
            
            var log = Log.Create(vote.UserId, logType, JsonConvert.SerializeObject(vote));

            _context.PostRepository.Add(post);
            _context.Entry(post).State = EntityState.Modified;
            _context.Save();

            _usageContext.LogRepository.Add(log);
            _usageContext.Entry(log.LogType).State = EntityState.Modified;
            _usageContext.Save();

            return Ok();
        }

        [Route("{id:guid}/votedown")]
        [HttpGet]
        public async Task<IHttpActionResult> VoteDown(Guid id)
        {
            var post = _postRepository.Get(id);
            post.VoteDown();

            _context.PostRepository.Add(post);
            _context.Entry(post).State = EntityState.Modified;
            _context.Save();

            return Ok();
        }

        [Route("votedown")]
        [HttpPost]
        public async Task<IHttpActionResult> VoteDown(VoteModel vote)
        {
            var logType = _logTypeRepository.GetLogTypeByName("PostVote");

            var usage = await _logRepository.GetByUserAndType(vote.UserId, logType.Id);

            var search = String.Format(@"""ArtifactId"":""{0}""", vote.ArtifactId);

            if (usage.Any(x => x.LogData.Contains(search)))
                return InternalServerError(new Exception("You have already voted on this post"));

            var post = _postRepository.Get(vote.ArtifactId);
            post.VoteDown();

            var log = Log.Create(vote.UserId, logType, JsonConvert.SerializeObject(vote));

            _context.PostRepository.Add(post);
            _context.Entry(post).State = EntityState.Modified;
            _context.Save();

            _usageContext.LogRepository.Add(log);
            _usageContext.Entry(log.LogType).State = EntityState.Modified;
            _usageContext.Save();

            return Ok();
        }
    }
}