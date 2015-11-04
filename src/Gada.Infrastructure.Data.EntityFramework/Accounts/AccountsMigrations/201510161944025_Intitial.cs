namespace Gada.Infrastructure.Data.EntityFramework.Accounts.AccountsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false),
                        Forename = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Interests",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Interest_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Interest_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User_Skills",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Skill_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Skill_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Skills", "User_Id", "dbo.Users");
            DropForeignKey("dbo.User_Interests", "User_Id", "dbo.Users");
            DropIndex("dbo.User_Skills", new[] { "User_Id" });
            DropIndex("dbo.User_Interests", new[] { "User_Id" });
            DropTable("dbo.User_Skills");
            DropTable("dbo.User_Interests");
            DropTable("dbo.Users");
        }
    }
}
