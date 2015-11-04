using System.Collections.Generic;
using System.Linq;
using Gada.Twitter.Entities;
using Gada.Twitter.Services;
using LinqToTwitter;

namespace Gada.Services.Twitter.Services
{
    public class TwitterService : ITwitterService
    {
        private const string _accessToken = "632025708-H99nbc5TDIacTxA79ZHnGSzKwEz0CLEQlnCrPFJJ";
        private const string _accessTokenSecret = "bkEDE4pQnHVybPxMliovlujtiC3PL8l9KkKZm2rsLFQ";

        private const string _consumerKey = "xfYohYSOEpmCReh7Bkwg";
        private const string _consumerSecret = "ktIi4NWrglsMAsD4hTdGEGCgBkL7wPuDowHy75drvs";

        private const string _twitterAccount = "Gada_democracy";

        private SingleUserAuthorizer Authorize()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    OAuthToken = _accessToken,
                    OAuthTokenSecret = _accessTokenSecret
                }
            };

            return auth;
        }

        public IList<Tweet> GetLatestTweets(int count)
        {
            var twitterContext = new TwitterContext(Authorize());

            var tweets = new List<Tweet>();

            var statusTweets = from tweet in twitterContext.Status
                               where tweet.Type == StatusType.User &&
                                       tweet.ScreenName == _twitterAccount &&
                                       tweet.IncludeContributorDetails == true &&
                                       tweet.Count == 10 &&
                                       tweet.IncludeEntities == true
                               select tweet;

            foreach (var statusTweet in statusTweets)
            {
                tweets.Add(Tweet.Create(statusTweet.User.ProfileImageUrl, statusTweet.User.ScreenName,
                    GetTweetMediaUrl(statusTweet), statusTweet.Text));
            }

            return tweets;
        }

        private string GetTweetMediaUrl(Status status)
        {
            if (status.Entities != null && status.Entities.MediaEntities.Count > 0)
            {
                return status.Entities.MediaEntities[0].MediaUrlHttps;
            }

            return "";
        }
    }
}
