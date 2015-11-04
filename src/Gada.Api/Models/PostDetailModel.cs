using System;

namespace Gada.Api.Models
{
    public class PostDetailModel
    {
        public Guid Id { get; set; }
        public string Post { get; set; }
        public string Posted { get; set; }
        public string PostedBy { get; set; }
        public int Votes { get; set; }
    }
}