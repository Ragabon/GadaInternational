using System.Data.Entity.ModelConfiguration;
using Gada.Discussions.Entities;


namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions
{
    public class DiscussionInterestMap: EntityTypeConfiguration<DiscussionInterest>
    {
        public DiscussionInterestMap()
        {
            ToTable("DiscussionInterests");

            HasKey(x => new {x.Discussion_Id, x.Interest_Id});

            Property(x => x.Interest_Id).IsRequired();
        }
    }
}
