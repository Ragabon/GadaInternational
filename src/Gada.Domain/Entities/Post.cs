using System;
using System.Collections.Generic;
using Gada.Domain;

namespace Gada.Discussions.Entities
{
    public class Post : IEntity
    {
        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public DateTime PostedOn { get; private set; }
        public Guid PostedBy_Id { get; private set; }
        public User PostedBy { get; private set; }
        public bool Show { get; private set; }
        public int Votes { get; private set; }
        public List<Comment> Comments { get; private set; }
        public Discussion Discussion { get; private set; }


        public static Post CreatePost(string content, User user)
        {
            var post = new Post()
            {
                Id = Guid.NewGuid(),
                Content = content,
                PostedOn = DateTime.Now.ToUniversalTime(),
                PostedBy_Id = user.Id,
                PostedBy = user,
                Show = true,
                Votes = 0,
                Comments = new List<Comment>()
            };
            return post;
        }

        public void VoteUp()
        {
            Votes++;
        }
        public void VoteDown()
        {
            Votes--;
        }

        public void HidePost()
        {
            Show = false;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void SetPostedBy(User user)
        {
            PostedBy_Id = user.Id;
            PostedBy = user;
        }

        public void SetDiscussion(Discussion discussion)
        {
            Discussion = discussion;
        }
    }
}
