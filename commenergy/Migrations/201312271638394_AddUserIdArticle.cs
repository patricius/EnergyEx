namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdArticle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ArticleID", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "ArticleID" });
            AddColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "ArticleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "UserId");
            CreateIndex("dbo.Comments", "ArticleId");
            AddForeignKey("dbo.Articles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
       
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "URL", c => c.String());
            AddColumn("dbo.Articles", "IpAddress", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "Email", c => c.String(nullable: false));
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            AlterColumn("dbo.Comments", "ArticleId", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "UserId");
            CreateIndex("dbo.Comments", "ArticleID");
            AddForeignKey("dbo.Comments", "ArticleID", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
