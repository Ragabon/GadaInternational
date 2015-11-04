using Gada.Skills.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Skills
{
    public class SkillCategoryMap : EntityTypeConfiguration<SkillCategory>
    {
        public SkillCategoryMap()
        {
            HasKey(x => x.Id);

            Property(x => x.CategoryName).IsRequired();
        }
    }
}