using System;

namespace Gada.Api.Models
{
    public class VoteModel
    {
        public Guid ArtifactId { get; set; }
        public Guid UserId { get; set; }
        public bool UpVote { get; set; }
    }
}