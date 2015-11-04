namespace Gada.Twitter.Entities
{
    public class Tweet
    {
        public string ImageUrl { get; private set; }
        public string ScreenName { get; private set; }
        public string MediaUrl { get; private set; }
        public string Content { get; private set; }

        public static Tweet Create(string imageUrl, string screenName, string mediaUrl, string tweet)
        {
            return new Tweet()
            {
                ImageUrl = imageUrl,
                ScreenName = screenName,
                MediaUrl = mediaUrl,
                Content = tweet
            };
        }
    }
}
