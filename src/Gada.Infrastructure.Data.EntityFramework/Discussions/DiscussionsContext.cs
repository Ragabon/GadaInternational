using Gada.Discussions;
using Gada.Discussions.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Gada.Domain;
using Gada.Infrastructure.Data.EntityFramework.Mapping.Discussions;

namespace Gada.Infrastructure.Data.EntityFramework
{
    public partial class DiscussionsContext : DbContext, IDiscussionsContext
    {
        private readonly Repository<Discussion> _discussionRepository;

        private readonly Repository<Post> _postRepository;

        private readonly Repository<Interest> _interestsRepository;

        private readonly Repository<Area> _areasRepository;

        private readonly Repository<User> _usersRepository;

        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<User> Users { get; set; }

        public Database Db { get { return Database; } }

        public DiscussionsContext()
            : base ("GadaContext")
        {
            _discussionRepository = new Repository<Discussion>(Discussions);

            _postRepository = new Repository<Post>(Posts);

            _interestsRepository = new Repository<Interest>(Interests);

            _areasRepository = new Repository<Area>(Areas);
            
            _usersRepository = new Repository<User>(Users);

            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

            Database.SetInitializer<DiscussionsContext>(new NullDatabaseInitializer<DiscussionsContext>());
        }

        public IRepository<Discussion> DiscussionRepository
        {
            get { return _discussionRepository; }
        }

        public IRepository<Post> PostRepository
        {
            get { return _postRepository; }
        }

        public IRepository<Interest> InterestsRepostory
        {
            get { return _interestsRepository; }
        }

        public IRepository<Area> AreasRepository
        {
            get { return _areasRepository; }
        }

        public IRepository<User> UsersRepository
        {
            get { return _usersRepository; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new DiscussionMap());
            modelBuilder.Configurations.Add(new DiscussionInterestMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new AreaMap());

            modelBuilder.Ignore<Interest>();
            modelBuilder.Ignore<User>();

            //modelBuilder.Configurations.Add(new InterestMap());
            //modelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
