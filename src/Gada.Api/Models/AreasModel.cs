using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gada.Api.Models
{
    public class AreasModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}