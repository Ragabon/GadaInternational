using System;

namespace Gada.Discussions.Entities
{
    public class DiscussionInterest
    {
        public Discussion Discussion { get; private set; }
        
        public Guid Discussion_Id { get; private set; }
        public Guid Interest_Id { get; private set; }

        public static DiscussionInterest Create(Discussion discussion, Guid interestId)
        {
            return new DiscussionInterest()
            {
                Discussion = discussion,
                Discussion_Id = discussion.Id,
                Interest_Id = interestId
            };
        }
    }
}
