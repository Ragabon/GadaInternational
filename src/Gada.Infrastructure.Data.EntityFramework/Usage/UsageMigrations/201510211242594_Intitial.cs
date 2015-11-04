namespace Gada.Infrastructure.Data.EntityFramework.Usage.UsageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        LoggedOn = c.DateTime(nullable: false),
                        LogData = c.String(nullable: false),
                        LogType_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogTypes", t => t.LogType_Id, cascadeDelete: true)
                .Index(t => t.LogType_Id);
            
            CreateTable(
                "dbo.LogTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "LogType_Id", "dbo.LogTypes");
            DropIndex("dbo.Logs", new[] { "LogType_Id" });
            DropTable("dbo.LogTypes");
            DropTable("dbo.Logs");
        }
    }
}
