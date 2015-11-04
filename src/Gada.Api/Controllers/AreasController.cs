using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;
using Gada.Discussions;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gada.Api.Controllers
{
    [RoutePrefix("api/areas")]
    public class AreasController : ApiController
    {
        private readonly IAreasRepository<Area> _areasRepository;

        public AreasController(IAreasRepository<Area> areasRepository)
        {
            _areasRepository = areasRepository;

            Mapper.AddProfile<AreasMappingProfile>();
        }

        // GET api/<controller>
        [Route("all")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var areas = await _areasRepository.GetAll();

            return Ok(Mapper.Map<IEnumerable<Area>, IEnumerable<AreasModel>>(areas));
        }
    }
}