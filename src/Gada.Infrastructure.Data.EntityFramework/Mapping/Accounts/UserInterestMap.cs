using System.Data.Entity.ModelConfiguration;
using Gada.Users.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Accounts
{
    public class UserInterestMap : EntityTypeConfiguration<UserInterest>
    {
        public UserInterestMap()
        {
            ToTable("User_Interests");

            HasKey(x => new {x.User_Id, x.Interest_Id});

            Property(x => x.Interest_Id).IsRequired();
        }
    }
}
