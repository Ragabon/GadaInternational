namespace Gada.Infrastructure.Data.EntityFramework.Skills.SkillsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Category_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkillCategories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Category_Id", "dbo.SkillCategories");
            DropIndex("dbo.Skills", new[] { "Category_Id" });
            DropTable("dbo.Skills");
            DropTable("dbo.SkillCategories");
        }
    }
}
