using System;

namespace Gada.Api.Models
{
    public class CreatePostModel
    {
        public Guid UserId { get; set; }

        public Guid DiscussionId { get; set; }

        public string Content { get; set; }
    }
}