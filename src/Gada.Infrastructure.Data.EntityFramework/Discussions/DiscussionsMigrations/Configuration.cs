namespace Gada.Infrastructure.Data.EntityFramework.Discussions.DiscussionsMigrations
{
    using Gada.Discussions.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gada.Infrastructure.Data.EntityFramework.DiscussionsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Discussions\DiscussionsMigrations";
        }

        protected override void Seed(Gada.Infrastructure.Data.EntityFramework.DiscussionsContext context)
        {
            var governance = Area.Create("Democracy & Governance",
                "Democracy is in a bad shape. How can we fix it? We welcome ideas to... improve political participation, promote transparency, ensure the fair and balanced representation of all citizens...and fix the broken political system!",
                "fa-university");
            var justice = Area.Create("Social & Economic Justice",
                "Economic inequality is increasing, human rights are being eroded and xenophobia is on the rise. How can we build a society that is fair, tolerant and safe at the same time?",
                "fa-balance-scale");
            var environment = Area.Create("Environment & Climate",
                "Ever worried about climate change, food security, pollution or unprecedented wildlife extinction? We are thrashing our planet and don't know how to change course...but maybe you do",
                "fa-leaf");

            context.Areas.Add(governance);
            context.Areas.Add(justice);
            context.Areas.Add(environment);

            context.SaveChanges();
        }
    }
}
