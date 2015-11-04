using System.Data.Entity.ModelConfiguration;
using Gada.Accounts.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Accounts
{
    public class InterestMap : EntityTypeConfiguration<Interest>
    {
        public InterestMap()
        {
            ToTable("Interests");

            HasKey(x => x.Id);

            Property(x => x.Title).IsRequired();
        }
    }
}
