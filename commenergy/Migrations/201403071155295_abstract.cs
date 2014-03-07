namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _abstract : DbMigration
    {
        public override void Up()
        {
           AlterColumn("dbo.Articles", "Abstract", c => c.String());
            Sql("UPDATE dbo.Articles SET Abstract = LEFT(Body, 100) WHERE Abstract IS NULL"); 
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Abstract");
        }
    }
}
