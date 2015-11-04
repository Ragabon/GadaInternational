namespace Gada.Infrastructure.Data.EntityFramework.Interests.InterestsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InterestCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Category_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterestCategories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interests", "Category_Id", "dbo.InterestCategories");
            DropIndex("dbo.Interests", new[] { "Category_Id" });
            DropTable("dbo.Interests");
            DropTable("dbo.InterestCategories");
        }
    }
}
