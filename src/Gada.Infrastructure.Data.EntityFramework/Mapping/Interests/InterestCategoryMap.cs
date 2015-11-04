using Gada.Interests.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Interests
{
    public class InterestCategoryMap : EntityTypeConfiguration<InterestCategory>
    {
        public InterestCategoryMap()
        {
            HasKey(x => x.Id);

            Property(x => x.CategoryName).IsRequired();
        }
    }
}