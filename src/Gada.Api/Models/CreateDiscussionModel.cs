using System;
using System.Collections.Generic;

namespace Gada.Api.Models
{
    public class CreateDiscussionModel
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Area { get; set; }

        public List<InterestModel> Interests { get; set; }
    }

    public class InterestModel
    {
        public string Text { get; set; }
    }
}