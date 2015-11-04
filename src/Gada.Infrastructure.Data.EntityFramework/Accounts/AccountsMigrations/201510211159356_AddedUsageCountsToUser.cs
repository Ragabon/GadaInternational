namespace Gada.Infrastructure.Data.EntityFramework.Accounts.AccountsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUsageCountsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DiscussionsCreated", c => c.Int());
            AddColumn("dbo.Users", "Posts", c => c.Int());
            AddColumn("dbo.Users", "Comments", c => c.Int());
            AddColumn("dbo.Users", "UpVotes", c => c.Int());
            AddColumn("dbo.Users", "DownVotes", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DownVotes");
            DropColumn("dbo.Users", "UpVotes");
            DropColumn("dbo.Users", "Comments");
            DropColumn("dbo.Users", "Posts");
            DropColumn("dbo.Users", "DiscussionsCreated");
        }
    }
}
