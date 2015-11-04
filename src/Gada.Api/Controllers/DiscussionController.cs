using System.Data.Entity;
using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;
using Gada.Discussions;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Gada.Interests.Repositories;

namespace Gada.Api
{
    [RoutePrefix("api/discussions")]
    public class DiscussionController : ApiController
    {
        private readonly IDiscussionsContext _context;
        private readonly IDiscussionRepository<Discussion> _discussionRepository;
        private readonly IUsersRepository<User> _userRepository;
        private readonly IAreasRepository<Area> _areasRepository;
        private readonly IInterestsRepository<Gada.Interests.Entities.Interest> _interestsRepository;

        public DiscussionController(IDiscussionsContext context,
            IDiscussionRepository<Discussion> discussionRepository, IUsersRepository<User> userRepository,
            IAreasRepository<Area> areasRepository, IInterestsRepository<Gada.Interests.Entities.Interest> interestsRepository)
        {
            _context = context;
            _discussionRepository = discussionRepository;
            _userRepository = userRepository;
            _areasRepository = areasRepository;
            _interestsRepository = interestsRepository;

            Mapper.AddProfile<DiscussionsMappingProfile>();
            Mapper.AddProfile<PostsMappingProfile>();
        }

        // GET api/<controller>
        [Route()]
        [HttpGet]
        public async Task<IHttpActionResult> Get() //<IEnumerable<DiscussionListModel>>
        {
            var discussions = await _discussionRepository.GetList();

            return Ok(Mapper.Map<IEnumerable<Discussion>, IEnumerable<DiscussionListModel>>(discussions));
        }

        [Route("latest")]
        [HttpGet]
        public async Task<IHttpActionResult> GetLatest() //<IEnumerable<DiscussionListModel>>
        {
            var discussions = await _discussionRepository.GetLatest();

            return Ok(Mapper.Map<IEnumerable<Discussion>, IEnumerable<DiscussionListModel>>(discussions));
        }

        [Route("area/{area:guid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByArea(Guid area) //<IEnumerable<DiscussionListModel>>
        {
            var discussions = await _discussionRepository.GetListByArea(area);

            return Ok(Mapper.Map<IEnumerable<Discussion>, IEnumerable<DiscussionListModel>>(discussions));
        }

        [Route("related/{id:guid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRelated(Guid id) //<IEnumerable<DiscussionListModel>>
        {
            var discussions = await _discussionRepository.GetRelated(id);

            return Ok(Mapper.Map<IEnumerable<Discussion>, IEnumerable<DiscussionListModel>>(discussions));
        }

        [Route("{id:guid}")]
        [HttpGet]
        public DiscussionDetailModel Get(Guid id)
        {
            var discussion = _discussionRepository.FindById(id);

            return Mapper.Map<Discussion, DiscussionDetailModel>(discussion);
        }

        [Route("{id:guid}/voteup")]
        [HttpGet]
        public async Task<IHttpActionResult> VoteUp(Guid id)
        {
            var discussion = _discussionRepository.Get(id);
            discussion.VoteUp();
            
            _context.DiscussionRepository.Add(discussion);
            _context.Entry(discussion).State = EntityState.Modified;
            _context.Save();

            return Ok();
        }

        [Route("{id:guid}/votedown")]
        [HttpGet]
        public async Task<IHttpActionResult> VoteDown(Guid id)
        {
            var discussion = _discussionRepository.Get(id);
            discussion.VoteDown();

            _context.DiscussionRepository.Add(discussion);
            _context.Entry(discussion).State = EntityState.Modified;
            _context.Save();

            return Ok();
        }

        // POST api/<controller>
        [Route("add")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(CreateDiscussionModel discussion)
        {
            try
            { 
            var user = _userRepository.GetById(discussion.UserId);

            var area = _areasRepository.Get(discussion.Area);

            string[] titles = discussion.Interests.Select(x => x.Text.Replace("-"," ")).ToArray();

            var interests = Mapper.Map<IEnumerable<Gada.Interests.Entities.Interest>, IEnumerable<Interest>>(_interestsRepository.Get(titles).ToList());

            var newDiscussion = Discussion.CreateDiscussion(discussion.Title, discussion.Description, user, interests.ToList(), false, area);
            _context.DiscussionRepository.Add(newDiscussion);
            _context.Entry(newDiscussion).State = EntityState.Added;
            //_context.Entry(newDiscussion.CreatedBy).State = EntityState.Unchanged;
            _context.Entry(newDiscussion.Area).State = EntityState.Unchanged;

            //for (int i = 0; i < interests.ToList().Count; i++)
            //{
            //    _context.Entry(newDiscussion.Interests[i]).State = EntityState.Unchanged;
            //}

            _context.Save();

            return Ok();
                }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [Route("edit")]
        [HttpPut]
        public void Put(Discussion discussion)
        {
        }

        // DELETE api/<controller>/5
        [Route("{id:guid}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
        }
    }
}