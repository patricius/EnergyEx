namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wwwm : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.AspNetRoles", newSchema: "dbo.AspNetUsers");
            RenameTable(name: "[dbo.AspNetUsers].AspNetRoles", newName: "dbo.AspNetRoles");
        }
    }
}
