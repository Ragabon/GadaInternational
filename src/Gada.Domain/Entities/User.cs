using System;
using Gada.Domain;

namespace Gada.Discussions.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public static User CreateUser(string username)
        {
            return new User() {Id = Guid.NewGuid(), Username = username};
        }
    }
}
