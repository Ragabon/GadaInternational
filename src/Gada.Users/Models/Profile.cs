using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Accounts.Models
{
    public class Profile
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public DateTime MemberSince { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public int DiscussionsCreated { get; set; }

        public int Posts { get; set; }

        public int Comments { get; set; }

        //public IEnumerable<Interest> Interests {get;set;}

    }
}
