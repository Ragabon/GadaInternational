using System;

namespace Gada.Api.Models
{
    public class NewsFeedModel
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedOnRelativeTime { get; set; }
        public string Event { get; set; }
        public string Content { get; set; }
        public string UpdateId { get; set; }
        public UpdateType UpdateType { get; set; }
    }

    public enum UpdateType
    {
        Discussion
    }
}