using System.Data.Entity.ModelConfiguration;
using Gada.Usage.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Mapping.Usage
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            HasKey(x => x.Id);

            Property(x => x.UserId).IsRequired();
            Property(x => x.LoggedOn).IsRequired();
            Property(x => x.LogData).IsRequired();
            
            HasRequired(x => x.LogType);
        }
    }
}
