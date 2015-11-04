using Gada.Discussions.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions
{
    public class AreaMap: EntityTypeConfiguration<Area>
    {
        public AreaMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Title).IsRequired();
            Property(x => x.Description).IsOptional();
            Property(x => x.Icon).IsOptional();
        }
    }
}
