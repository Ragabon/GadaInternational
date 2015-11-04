using Gada.Skills.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Skills
{
    public class SkillMap : EntityTypeConfiguration<Skill>
    {
        public SkillMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Title).IsRequired();

            HasRequired(x => x.Category);
        }
    }
}