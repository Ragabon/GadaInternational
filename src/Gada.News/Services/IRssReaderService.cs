using Gada.News.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gada.News.Services
{
    public interface IRssReaderService
    {
        Task<IList<RssFeed>> GetFeeds(int? noOfFeeds = null);
    }
}
