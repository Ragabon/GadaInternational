using System.Data.Entity.ModelConfiguration;
using Gada.Usage.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Usage
{
    public class LogTypeMap : EntityTypeConfiguration<LogType>
    {
        public LogTypeMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Type).IsRequired();
        }
    }
}
