namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationfixnullable : DbMigration
    {
        public override void Up()
        {

            DropForeignKey("dbo.Comments", "ArticleID", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "ArticleID" });
   
            AlterColumn("dbo.Comments", "ArticleId", c => c.Int(nullable: true));
         
            CreateIndex("dbo.Comments", "ArticleId");
          
        }
        
        public override void Down()
        {
        }
    }
}
