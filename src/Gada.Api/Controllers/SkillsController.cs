using Gada.Skills;
using Gada.Skills.Entities;
using Gada.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;

namespace Gada.Api.Controllers
{
    [RoutePrefix("api/skills")]
    public class SkillsController : ApiController
    {
        private readonly ISkillsContext _context;
        private readonly ISkillsRepository<Skill> _skillsRepository;

        public SkillsController(ISkillsContext context, ISkillsRepository<Skill> skillsRepository)
        {
            _context = context;
            _skillsRepository = skillsRepository;

            Mapper.AddProfile<SkillsMappingProfile>();
        }

        [Route("all")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var skills = await _skillsRepository.GetAll();

                return Ok(Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillsModel>>(skills));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("find/{query}")]
        [HttpGet]
        public async Task<IHttpActionResult> Find(string query)
        {
            try
            {
                var skills = await _skillsRepository.Find(query);

                return Ok(Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillsModel>>(skills));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
