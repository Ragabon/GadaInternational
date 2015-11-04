using System;
using System.Collections.Generic;

namespace Gada.Api.Models
{
    public class ProfileModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public DateTime MemberSince { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public int DiscussionsCreated { get; set; }

        public int Posts { get; set; }

        public int Comments { get; set; }

        public List<InterestsModel> Interests { get; set; }

        public List<SkillsModel> Skills { get; set; } 
    }
}