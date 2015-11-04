﻿using System;
using System.Collections.Generic;


namespace Gada.Api.Models
{
    public class DiscussionDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public int Votes { get; set; }
        public int Views { get; set; }
        public List<string> Interests { get; set; }
        public List<PostDetailModel> Posts { get; set; } 
    }
}