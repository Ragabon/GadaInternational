namespace Gada.Infrastructure.Data.EntityFramework.Discussions.DiscussionsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(),
                        CreatedBy_Id = c.Guid(nullable: false),
                        ClosedOn = c.DateTime(),
                        ReceiveUpdates = c.Boolean(nullable: false),
                        Votes = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        PostCount = c.Int(),
                        Area_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.Area_Id)
                .Index(t => t.Area_Id);
            
            CreateTable(
                "dbo.DiscussionInterests",
                c => new
                    {
                        Discussion_Id = c.Guid(nullable: false),
                        Interest_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discussion_Id, t.Interest_Id })
                .ForeignKey("dbo.Discussions", t => t.Discussion_Id, cascadeDelete: true)
                .Index(t => t.Discussion_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        PostedBy_Id = c.Guid(nullable: false),
                        Show = c.Boolean(nullable: false),
                        Votes = c.Int(nullable: false),
                        Discussion_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discussions", t => t.Discussion_Id)
                .Index(t => t.Discussion_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(nullable: false),
                        Show = c.Boolean(nullable: false),
                        Post_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Discussion_Id", "dbo.Discussions");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.DiscussionInterests", "Discussion_Id", "dbo.Discussions");
            DropForeignKey("dbo.Discussions", "Area_Id", "dbo.Areas");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "Discussion_Id" });
            DropIndex("dbo.DiscussionInterests", new[] { "Discussion_Id" });
            DropIndex("dbo.Discussions", new[] { "Area_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.DiscussionInterests");
            DropTable("dbo.Discussions");
            DropTable("dbo.Areas");
        }
    }
}
