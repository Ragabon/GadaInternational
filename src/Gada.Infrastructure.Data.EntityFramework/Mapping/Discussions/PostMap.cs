using System.Data.Entity.ModelConfiguration;
using Gada.Discussions.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Content).IsRequired();
            Property(x => x.PostedOn).IsRequired();
            Property(x => x.Show).IsRequired();
            Property(x => x.Votes).IsRequired();
            Property(x => x.PostedBy_Id).IsRequired();

            //HasRequired(x => x.PostedBy);
            
            HasMany(x => x.Comments).WithOptional();
        }
    }
}
