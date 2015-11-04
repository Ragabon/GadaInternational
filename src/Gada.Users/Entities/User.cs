using System;
using Gada.Accounts.Entities;
using System.Collections.Generic;
using System.Linq;
using Gada.Domain;
using Gada.Users.Entities;

namespace Gada.Accounts.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public int DiscussionsCreated { get; private set; }
        public int Posts { get; private set; }
        public int Comments { get; private set; }
        public int UpVotes { get; private set; }
        public int DownVotes { get; private set; }

        public List<UserInterest> UserInterests { get; private set; } 
        public List<Interest> Interests { get; private set; }

        public List<UserSkill> UserSkills { get; private set; } 
        public List<Skill> Skills { get; private set; }

        //protected User()
        //{
        //    UserInterests = new List<UserInterest>();
        //    Interests = new List<Interest>();
        //    UserSkills = new List<UserSkill>();
        //    Skills = new List<Skill>();
        //}

        public static User CreateUser(string username, string forename, string surname, string email, string city, string country)
        {
            return new User() { Id = Guid.NewGuid(), Username = username, Forename = forename, Surname = surname, Email = email, City = city, Country = country };
        }

        public void AddSkill(Skill skill)
        {
            UserSkills.Add(UserSkill.Create(this, skill.Id));
            Skills.Add(skill);
        }

        public void AddInterest(Interest interest)
        {
            UserInterests.Add(UserInterest.Create(this, interest.Id));
            Interests.Add(interest);
        }

        public void RemoveSkill(Skill skill)
        {
            UserSkills.Remove(UserSkills.FirstOrDefault(x => x.Skill_Id == skill.Id)); 
            Skills.Remove(skill);
        }

        public void RemoveInterest(Interest interest)
        {
            UserInterests.Remove(UserInterests.FirstOrDefault(x => x.Interest_Id == interest.Id)); 
            Interests.Remove(interest);
        }
    }
}
