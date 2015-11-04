using System.Collections.Generic;
using Gada.Skills.Entities;
using Gada.Usage.Entities;

namespace Gada.Infrastructure.Data.EntityFramework.Usage.UsageMigrations
{
    using System.Data.Entity.Migrations;
    
    internal sealed class Configuration : DbMigrationsConfiguration<Gada.Infrastructure.Data.EntityFramework.UsageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Usage\UsageMigrations";
        }

        protected override void Seed(Gada.Infrastructure.Data.EntityFramework.UsageContext context)
        {
            context.LogTypes.AddRange(GenerateLogTypes());
            context.SaveChanges();
        }

        public List<LogType> GenerateLogTypes()
        {
            var logTypes = new List<LogType>();
            logTypes.Add(LogType.Create("DiscussionVote"));
            logTypes.Add(LogType.Create("PostVote"));

            return logTypes;
        }
    }
}
