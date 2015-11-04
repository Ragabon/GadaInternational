using System;
using System.Collections.Generic;
using System.Linq;
using Gada.Domain;

namespace Gada.Discussions.Entities
{
    public class Discussion : IEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? LastModifiedOn { get; private set; }
        public Guid CreatedBy_Id { get; private set; }
        public User CreatedBy { get; private set; }

        public DateTime? ClosedOn { get; private set; }
        public List<DiscussionInterest> DiscussionInterests { get; private set; }
        public List<Interest> Interests { get; private set; }
        public List<Post> Posts { get; private set; }
        public bool ReceiveUpdates { get; private set; }
        public int Votes { get; private set; }
        public int Views { get; private set; }
        public Area Area { get; private set; }

        public int PostCount { get; private set; }
        
        protected Discussion()
        {
            Posts = new List<Post>();
            Interests = new List<Interest>();
            DiscussionInterests = new List<DiscussionInterest>();
        }

        public static Discussion CreateDiscussion(string title, string description, User user, List<Interest> interests, bool receiveUpdates, Area area)
        {
            var discussion = new Discussion()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CreatedBy_Id = user.Id,
                CreatedBy = user,
                CreatedOn = DateTime.Now.ToUniversalTime(),
                Interests = interests,
                ReceiveUpdates = receiveUpdates,
                Votes = 0,
                Views = 0,
                PostCount = 0,
                Posts = new List<Post>(),
                Area = area
            };

            discussion.DiscussionInterests = interests.Select(interest => DiscussionInterest.Create(discussion, interest.Id)).ToList();

            return discussion;
        }

        public void SetCreatedBy(User user)
        {
            CreatedBy_Id = user.Id;
            CreatedBy = user;
        }

        public void CloseDiscussion()
        {
            ClosedOn = DateTime.Now.ToUniversalTime();
        }

        public void AddPost(Post post)
        {
            Posts.Add(post);
            PostCount++;
        }

        public void AddInterest(Interest interest)
        {
            DiscussionInterests.Add(DiscussionInterest.Create(this, interest.Id));
            Interests.Add(interest);
        }

        public void VoteUp()
        {
            Votes++;
        }

        public void VoteDown()
        {
            Votes--;
        }

        public void AddView()
        {
            Views++;
        }
    }
}
