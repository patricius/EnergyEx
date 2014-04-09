namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {

        

            AddForeignKey("dbo.Articles", "UserId","dbo.AspNetUsers", "Id");
                
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
