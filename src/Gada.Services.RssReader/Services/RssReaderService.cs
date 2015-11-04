using Gada.News.Entities;
using Gada.News.Services;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace Gada.Services.RssReader.Services
{
    public class RssReaderService : IRssReaderService
    {
        public static string feedUrl = "http://feeds.bbci.co.uk/news/politics/rss.xml";
        public static string mediaUrl = "http://search.yahoo.com/mrss/";

        public async Task<IList<RssFeed>> GetFeeds(int? noOfFeeds)
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var xmlData = await client.DownloadStringTaskAsync(feedUrl);
            var media = XNamespace.Get(mediaUrl);

            XDocument xml = XDocument.Parse(xmlData);
            
            var newsUpdates = (from story in xml.Descendants("item") select
                                   RssFeed.Create(((string)story.Element("title")),
                                   ((string)story.Element("description")), ((string)story.Element("link")).Replace("http://", "https://"),
                                   ((string)story.Element("pubDate")),
                                   ((string)story.Element(media + "thumbnail") != null ? (string)story.Element(media + "thumbnail").Attribute("url").Value : "").Replace("http://","https://"),
                                   ((string)story.Element(media + "thumbnail") != null ? (string)story.Element(media + "thumbnail").Attribute("url").Value : "").Replace("http://", "https://")))
                                   .ToList();

            if(!noOfFeeds.HasValue)
                return newsUpdates;

            return newsUpdates.Take(noOfFeeds.Value).ToList();
        }
    }
}
