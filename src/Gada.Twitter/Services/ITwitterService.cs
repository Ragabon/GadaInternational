using System.Collections.Generic;
using Gada.Twitter.Entities;

namespace Gada.Twitter.Services
{
    public interface  ITwitterService
    {
        IList<Tweet> GetLatestTweets(int count);
    }
}
