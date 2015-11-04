using Gada.Discussions.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions
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
