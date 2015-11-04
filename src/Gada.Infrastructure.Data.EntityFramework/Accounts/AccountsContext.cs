using Gada.Accounts.Entities;
using System.Data.Entity;
using Gada.Infrastructure.Data.EntityFramework.Mapping.Accounts;
using Gada.Accounts;
using Gada.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gada.Infrastructure.Data.EntityFramework
{
    public class AccountsContext : DbContext, IAccountsContext
    {
        private readonly Repository<User> _accountRepository;

        public DbSet<User> Accounts { get; set; }

        public Database Db { get { return Database; } }

        public AccountsContext() : base ("GadaContext")
        {
            _accountRepository = new Repository<User>(Accounts);

            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

            Database.SetInitializer<AccountsContext>(new NullDatabaseInitializer<AccountsContext>());
        }

        public IRepository<User> AccountsRepository
        {
            get { return _accountRepository;  }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserSkillMap());
            modelBuilder.Configurations.Add(new UserInterestMap());
            
            //modelBuilder.Configurations.Add(new SkillMap());
            //modelBuilder.Configurations.Add(new InterestMap());

            modelBuilder.Ignore<Skill>();
            modelBuilder.Ignore<Interest>();

            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
