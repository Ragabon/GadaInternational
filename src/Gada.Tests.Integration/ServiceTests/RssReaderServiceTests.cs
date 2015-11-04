using Gada.Services.RssReader.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Gada.Tests.Integration.ServiceTests
{
    [TestFixture]
    public class RssReaderServiceTests
    {
        [SetUp]
        public void TestInit()
        {

        }

        [Test]
        public async Task Rss_Reader_Should_Return_Feeds()
        {
            var reader = new RssReaderService();

            var feeds = await reader.GetFeeds(10);

            Assert.IsTrue(feeds.Count > 0);
        }
    }
}
