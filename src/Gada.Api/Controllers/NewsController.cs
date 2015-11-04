using AutoMapper;
using Gada.Api.AutoMappings;
using Gada.Api.Models;
using Gada.News.Entities;
using Gada.News.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gada.Api
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {
        private readonly IRssReaderService _rssReaderService;
 
        public NewsController(IRssReaderService rssReaderService)
        {
            _rssReaderService = rssReaderService;

            Mapper.AddProfile<NewsMappingProfile>();
        }

        [Route()]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var feeds = await _rssReaderService.GetFeeds();

            return Ok(Mapper.Map<IEnumerable<RssFeed>, IEnumerable<NewsListModel>>(feeds));
        }

        [Route("latest")]
        [HttpGet]
        public async Task<IHttpActionResult> GetLatest()
        {
            var feeds = await _rssReaderService.GetFeeds(10);

            return Ok(Mapper.Map<IEnumerable<RssFeed>, IEnumerable<NewsListModel>>(feeds));
        }
    }
}
