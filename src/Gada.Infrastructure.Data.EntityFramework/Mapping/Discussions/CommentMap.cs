using Gada.Discussions.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Content).IsRequired();
            Property(x => x.CreatedOn).IsRequired();
            Property(x => x.Show).IsRequired();
            Property(x => x.CreatedBy_Id).IsRequired();

            //HasRequired(x => x.CreatedBy);
        }
    }
}
