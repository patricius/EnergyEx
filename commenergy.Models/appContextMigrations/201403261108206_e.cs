namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ImagePath");
        }
    }
}
