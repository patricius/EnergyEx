namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _abstract : DbMigration
    {
        public override void Up()
        {
           AlterColumn("dbo.Articles", "Abstract", c => c.String());
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Abstract");
        }
    }
}
