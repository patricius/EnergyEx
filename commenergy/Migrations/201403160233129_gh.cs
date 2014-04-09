namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gh : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Articles SET Abstract = LEFT(Body, 100) WHERE Abstract IS NULL"); 
        }
        
        public override void Down()
        {
        }
    }
}
