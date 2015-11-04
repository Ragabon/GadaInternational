using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Gada.Domain;
using Gada.Infrastructure.Data.EntityFramework.Mapping.Usage;
using Gada.Usage;
using Gada.Usage.Entities;

namespace Gada.Infrastructure.Data.EntityFramework
{
    public class UsageContext : DbContext, IUsageContext
    {
        private readonly Repository<Log> _logRepository;
        private readonly Repository<LogType> _logTypeRepository;

        public DbSet<Log> Logs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }

        public Database Db { get { return Database; } }

        public UsageContext()
            : base("GadaContext")
        {
            _logRepository = new Repository<Log>(Logs);
            _logTypeRepository = new Repository<LogType>(LogTypes);

            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

            Database.SetInitializer<EntityFramework.UsageContext>(new NullDatabaseInitializer<EntityFramework.UsageContext>());
        }

        public IRepository<Log> LogRepository
        {
            get { return _logRepository; }
        }

        public IRepository<LogType> LogTypeRepository
        {
            get { return _logTypeRepository; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new LogMap());
            modelBuilder.Configurations.Add(new LogTypeMap());
            
            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
