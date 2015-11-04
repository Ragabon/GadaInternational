namespace Gada.News.Entities
{
    public class RssFeed
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public string PublishedOn { get; private set; }
        public string Image { get; private set; }
        public string Thumbnail { get; private set; }

        public static RssFeed Create(string title, string description, string link, string publishedOn, string image, string thumbnail)
        {
            return new RssFeed()
            {
                Title = title,
                Description = description,
                Link = link,
                PublishedOn = publishedOn,
                Image = image,
                Thumbnail = thumbnail
            };
        }
    }
}
