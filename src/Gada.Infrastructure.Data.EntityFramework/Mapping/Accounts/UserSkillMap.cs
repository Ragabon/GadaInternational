using System.Data.Entity.ModelConfiguration;
using Gada.Users.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Accounts
{
    public class UserSkillMap : EntityTypeConfiguration<UserSkill>
    {
        public UserSkillMap()
        {
            ToTable("User_Skills");

            HasKey(x => new {x.User_Id, x.Skill_Id});

            Property(x => x.Skill_Id).IsRequired();
        }
    }
}
