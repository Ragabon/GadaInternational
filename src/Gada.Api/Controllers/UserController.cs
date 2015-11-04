using Gada.Api.Models;
using Gada.Accounts;
using Gada.Accounts.Entities;
using Gada.Accounts.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gada.Api
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IAccountsContext _context;
        private readonly IAccountsRepository<User> _userRepository;

        public UserController(IAccountsContext context, IAccountsRepository<User> userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //Why does this method not receive the data?
        [Route("GetUserByEmail")]
        [HttpPost]
        public async Task<IHttpActionResult> GetUser(GetUserModel gum)
        {
            var user = _userRepository.GetByEmail(gum.Email);
            return Ok(user);
        }

        [Route("GetProfile/{id:guid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProfile(Guid id)
        {
            //return Ok(_userRepository.GetProfile(id));
            return Ok();
        }

        [Route("{id:guid}/interest")]
        [HttpGet]
        public async Task<IHttpActionResult> GetInterests(Guid id)
        {
            //var interests = _userRepository
            return Ok();
        }

        [Route("{id:guid}/skill")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSkills(Guid id)
        {
            return Ok();
        }


        [Route("create")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateUser (CreateUserModel user)
        {
            var username = await GenerateUsername(user.Forename, user.Surname);
            var newUser = Gada.Accounts.Entities.User.CreateUser(username, user.Forename, user.Surname, user.Email, user.City, user.Country);

            _context.AccountsRepository.Add(newUser);
            _context.Save();

            return Ok(newUser);
        }

        private async Task<string> GenerateUsername(string forename, string surname)
        {
            string un = forename + surname.Substring(0, 2);
            var unCount = await _userRepository.GetCountOfUsernames(un);
            string num = (unCount + 1).ToString();
            while (num.Length < 3)
            {
                num = "0" + num;
            }
            string username = un + num;
            
            return username;
        }
    }
}