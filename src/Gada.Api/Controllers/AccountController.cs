using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Gada.Accounts;
using Gada.Accounts.Entities;
using Gada.Accounts.Repositories;
using Gada.Api.Models;

namespace Gada.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IAccountsContext _context;
        private readonly IAccountsRepository<User> _accountsRepository;

        public AccountController(IAccountsContext context, IAccountsRepository<User> accountsRepository)
        {
            _context = context;
            _accountsRepository = accountsRepository;
        }

        [Route("{userId:guid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAccountByUserId(Guid userId)
        {
            var user = _accountsRepository.GetById(userId);

            var profile = new ProfileModel()
            {
                Id = userId,
                Username = user.Username,
                DiscussionsCreated = user.DiscussionsCreated,
                Posts = user.Posts,
                Comments = user.Comments,
                UpVotes = user.UpVotes,
                DownVotes = user.DownVotes
            };

            return Ok(profile);
        }
    }
}
