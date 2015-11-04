using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gada.Api.Models
{
    public class NewsListModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Thumbnail { get; set; }
    }
}