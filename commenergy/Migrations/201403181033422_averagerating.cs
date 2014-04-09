namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class averagerating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "AvgRating", c => c.Single(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "AvgRating", c => c.Int());
        }
    }
}
