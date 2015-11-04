using Gada.Domain;
using Gada.Interests;
using Gada.Interests.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using Gada.Infrastructure.Data.EntityFramework.Mapping.Interests;

namespace Gada.Infrastructure.Data.EntityFramework
{
    public class InterestsContext : DbContext, IInterestsContext
    {
        private readonly Repository<Interest> _interestRepository;

        private readonly Repository<InterestCategory> _interestCategoryRepository;

        public DbSet<Interest> Interests { get; set; }

        public DbSet<InterestCategory> InterestCategories { get; set; }

        public Database Db { get { return Database; } }

        public InterestsContext() : base ("GadaContext") {

            _interestRepository = new Repository<Interest>(Interests);

            _interestCategoryRepository = new Repository<InterestCategory>(InterestCategories);

            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

            Database.SetInitializer<InterestsContext>(new NullDatabaseInitializer<InterestsContext>());
        }

        public IRepository<Interest> InterestRepository
        {
            get { return _interestRepository; }
        }

        public IRepository<InterestCategory> InterestCategoryRepository
        {
            get { return _interestCategoryRepository; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new InterestMap());
            modelBuilder.Configurations.Add(new InterestCategoryMap());

            base.OnModelCreating(modelBuilder);

        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
