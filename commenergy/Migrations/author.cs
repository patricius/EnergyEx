namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class author: DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Author", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}
