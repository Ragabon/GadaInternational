using System;
using Gada.Accounts.Entities;

namespace Gada.Users.Entities
{
    public class UserSkill
    {
        public User User { get; private set; }
        public Guid User_Id { get; private set; }
        public Guid Skill_Id { get; private set; }

        public static UserSkill Create(User user, Guid skillId)
        {
            return new UserSkill()
            {
                User = user,
                User_Id = user.Id,
                Skill_Id = skillId
            };
        }
    }
}
