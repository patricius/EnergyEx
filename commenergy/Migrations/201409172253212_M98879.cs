namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M98879 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Ratings", "ArticleId", "dbo.Articles");
            DropPrimaryKey("dbo.Articles");
            AlterColumn("dbo.Articles", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Articles", "Id");
            AddForeignKey("dbo.Comments", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropPrimaryKey("dbo.Articles");
            AlterColumn("dbo.Articles", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Articles", "Id");
            AddForeignKey("dbo.Ratings", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
