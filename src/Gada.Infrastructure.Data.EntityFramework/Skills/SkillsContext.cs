using Gada.Domain;
using Gada.Infrastructure.Data.EntityFramework.Mapping.Skills;
using Gada.Skills;
using Gada.Skills.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gada.Infrastructure.Data.EntityFramework.Skills
{
    public class SkillsContext : DbContext, ISkillsContext
    {
        private readonly Repository<Skill> _skillRepository;

        private readonly Repository<SkillCategory> _skillCategoryRepository;

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SkillCategory> SkillCategories { get; set; }

        public Database Db { get { return Database; } }

        public SkillsContext()
            : base("GadaContext")
        {
            _skillRepository = new Repository<Skill>(Skills);

            _skillCategoryRepository = new Repository<SkillCategory>(SkillCategories);

            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

            Database.SetInitializer<SkillsContext>(new NullDatabaseInitializer<SkillsContext>());
        }

        public IRepository<Skill> SkillRepository
        {
            get { return _skillRepository; }
        }

        public IRepository<SkillCategory> SkillCategoryRepository
        {
            get { return _skillCategoryRepository; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new SkillMap());
            modelBuilder.Configurations.Add(new SkillCategoryMap());
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}