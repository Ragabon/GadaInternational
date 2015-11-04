using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gada.Api.Models
{
    public class CreateUserModel
    {
        public string Id { get; set; }
        public string Forename {get; set;}
        public string Surname {get; set;}
        public string Email {get; set;}
        public string City {get; set;}
        public string Country {get; set;}
    }
}