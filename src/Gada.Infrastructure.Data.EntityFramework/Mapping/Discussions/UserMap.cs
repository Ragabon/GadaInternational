using System.Data.Entity.ModelConfiguration;
using Gada.Discussions.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            HasKey(x => x.Id);

            Property(x => x.Username).IsRequired();

            Property(x => x.Email).IsOptional();
        }
    }

}
