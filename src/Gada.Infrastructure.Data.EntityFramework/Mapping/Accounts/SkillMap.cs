using System.Data.Entity.ModelConfiguration;
using Gada.Accounts.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Accounts
{
    public class SkillMap: EntityTypeConfiguration<Skill>
    {
        public SkillMap()
        {
            ToTable("Skills");

            HasKey(x => x.Id);

            Property(x => x.Title).IsRequired();
        }
    }
}
