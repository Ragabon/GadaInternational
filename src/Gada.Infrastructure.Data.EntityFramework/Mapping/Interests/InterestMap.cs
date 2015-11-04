using Gada.Interests.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Interests
{
    public class InterestMap : EntityTypeConfiguration<Interest>
    {
        public InterestMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Title).IsRequired();

            HasRequired(x => x.Category);
        }
    }
}
