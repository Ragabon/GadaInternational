using System.Data.Entity.ModelConfiguration;
using Gada.Accounts.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Accounts
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Username).IsRequired();

            Property(x => x.Forename).IsOptional();

            Property(x => x.Surname).IsOptional();

            Property(x => x.Email).IsOptional();

            Property(x => x.City).IsOptional();

            Property(x => x.Country).IsOptional();

            Property(x => x.DiscussionsCreated).IsOptional();

            Property(x => x.Posts).IsOptional();

            Property(x => x.Comments).IsOptional();

            Property(x => x.UpVotes).IsOptional();

            Property(x => x.DownVotes).IsOptional();
            
            //HasMany(x => x.Skills).WithMany().Map(x => x.ToTable("User_Skills").MapLeftKey("UserId").MapRightKey("SkillId"));
            HasMany(x => x.UserSkills).WithRequired(x => x.User).HasForeignKey(x => x.User_Id);

            //HasMany(x => x.Interests).WithMany().Map(x => x.ToTable("User_Interests").MapLeftKey("UserId").MapRightKey("InterestId"));
            HasMany(x => x.UserInterests).WithRequired(x => x.User).HasForeignKey(x => x.User_Id);
        }
    }
}
