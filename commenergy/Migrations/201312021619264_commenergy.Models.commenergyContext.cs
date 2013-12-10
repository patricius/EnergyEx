namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    public partial class commenergyModelscommenergyContext : DbMigration
    {
        public override void Up()
        {    

            DropColumn("dbo.Articles", "ArticleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "ArticleID", c => c.Int(nullable: false));
        }
    }
}
