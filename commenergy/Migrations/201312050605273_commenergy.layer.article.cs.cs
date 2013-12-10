namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commenergylayerarticlecs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "Email");
            DropColumn("dbo.Articles", "IpAddress");
            DropColumn("dbo.Articles", "URL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "URL", c => c.String());
            AddColumn("dbo.Articles", "IpAddress", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "Email", c => c.String(nullable: false));
        }
    }
}
