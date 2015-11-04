using System;
using Gada.Domain;

namespace Gada.Discussions.Entities
{
    public class Comment : IEntity
    {
        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public Guid CreatedBy_Id { get; private set; }
        public User CreatedBy { get; private set; }
        public bool Show { get; private set; }

        public static Comment CreateComment(Guid id, string content, User user)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Content = content,
                CreatedOn = DateTime.Now.ToUniversalTime(),
                CreatedBy_Id = user.Id,
                CreatedBy = user,
                Show = true
            };
            return comment;
        }

        public void RemoveComment()
        {
            Show = false;
        }
    }
}
