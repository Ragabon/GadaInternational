using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;
using Gada.Interests;
using Gada.Interests.Entities;
using Gada.Interests.Repositories;
using Gada.Interests.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gada.Api.Controllers
{
    [RoutePrefix("api/interests")]
    public class InterestController : ApiController
    {
        private readonly IInterestsContext _context;
        private readonly IInterestsRepository<Interest> _interestsRepository;

        public InterestController(IInterestsContext context,
            IInterestsRepository<Interest> interestRepository)
        {
            _context = context;
            _interestsRepository = interestRepository;

            Mapper.AddProfile<InterestsMappingProfile>();
        }

        // GET api/<controller>
        [Route("all")]
        [HttpGet]
        public async Task<IHttpActionResult> Get() //<IEnumerable<DiscussionListModel>>
        {
            var interests = await _interestsRepository.GetAll();

            return Ok(Mapper.Map<IEnumerable<Interest>, IEnumerable<InterestsModel>>(interests));
        }

        [Route("find/{query}")]
        [HttpGet]
        public async Task<IHttpActionResult> Find(string query) //<IEnumerable<DiscussionListModel>>
        {
            var interests = await _interestsRepository.Find(query);

            return Ok(Mapper.Map<IEnumerable<Interest>, IEnumerable<InterestsModel>>(interests));
        }
    }
}