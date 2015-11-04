using System.Data.Entity.ModelConfiguration;
using Gada.Discussions.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions
{
    public class DiscussionMap : EntityTypeConfiguration<Discussion>
    {
        public DiscussionMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Title).IsRequired();
            Property(x => x.Description).IsRequired();
            Property(x => x.CreatedOn).IsRequired();
            Property(x => x.LastModifiedOn).IsOptional();
            Property(x => x.ClosedOn).IsOptional();
            Property(x => x.ReceiveUpdates).IsRequired();
            Property(x => x.Votes).IsRequired();
            Property(x => x.Views).IsRequired();
            Property(x => x.PostCount).IsOptional();
            Property(x => x.CreatedBy_Id).IsRequired();
            
            //HasRequired(x => x.CreatedBy);
            HasOptional(x => x.Area);

            //HasMany(x => x.Interests).WithMany();
            HasMany(x => x.DiscussionInterests).WithRequired(x => x.Discussion).HasForeignKey(x => x.Discussion_Id);

            HasMany(x => x.Posts).WithOptional(x => x.Discussion);
        }
    }
}
