namespace Lektion31.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        PostedByID = c.Guid(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.PostedByID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.PostedByID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NewsCaptions",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.News", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.TagNews",
                c => new
                    {
                        Tag_ID = c.Guid(nullable: false),
                        News_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.News_ID })
                .ForeignKey("dbo.Tags", t => t.Tag_ID, cascadeDelete: true)
                .ForeignKey("dbo.News", t => t.News_ID, cascadeDelete: true)
                .Index(t => t.Tag_ID)
                .Index(t => t.News_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagNews", new[] { "News_ID" });
            DropIndex("dbo.TagNews", new[] { "Tag_ID" });
            DropIndex("dbo.NewsCaptions", new[] { "ID" });
            DropIndex("dbo.News", new[] { "CategoryID" });
            DropIndex("dbo.News", new[] { "PostedByID" });
            DropForeignKey("dbo.TagNews", "News_ID", "dbo.News");
            DropForeignKey("dbo.TagNews", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.NewsCaptions", "ID", "dbo.News");
            DropForeignKey("dbo.News", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.News", "PostedByID", "dbo.Users");
            DropTable("dbo.TagNews");
            DropTable("dbo.NewsCaptions");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.Users");
            DropTable("dbo.News");
        }
    }
}
