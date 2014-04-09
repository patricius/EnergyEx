namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appdbmodelupdate : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Article_Id", c => c.Int());
            DropForeignKey("dbo.Ratings", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Ratings", new[] { "ArticleId" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropColumn("dbo.Articles", "AvgRating");
            DropTable("dbo.Ratings");
            CreateIndex("dbo.Articles", "Article_Id");
            AddForeignKey("dbo.Articles", "Article_Id", "dbo.Articles", "Id");
        }
    }
}
