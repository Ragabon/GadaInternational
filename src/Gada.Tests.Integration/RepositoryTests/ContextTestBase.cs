using Gada.Discussions;
using NUnit.Framework;
using Gada.Infrastructure.Data.EntityFramework;
//using Gada.Infrastructure.Data.EntityFramework.Migrations;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Gada.Tests.Integration.RepositoryTests
{
    [TestFixture]
    abstract class ContextTestBase
    {
        protected IDiscussionsContext Context = new DiscussionsContext();

        [TestFixtureSetUp]
        public virtual void Setup()
        {
            //Context.Db.Delete();
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DiscussionsContext, Configuration>(true));

            //var dbMigrator = new DbMigrator(new Configuration());
            //dbMigrator.Update();
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            Context.Db.Delete();
        }
    }
}
