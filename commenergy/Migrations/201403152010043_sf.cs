namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sf : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Articles", new[] { "Article_Id" });
            DropColumn("dbo.Articles", "Article_Id");
        }
    }
}
