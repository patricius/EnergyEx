namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Articles", new[] { "Article_Id" });
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                //.ForeignKey("dbo.AspNetUsers", t => t.RatingId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ArticleId);
            
            AddColumn("dbo.Articles", "AvgRating", c => c.Int(nullable: true));
           ;
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
