namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m999 : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            MoveTable(name: "[dbo.AspNetUsers].[dbo.AspNetRoles]", newSchema: "dbo");
            RenameTable(name: "dbo.AspNetRoles", newName: "AspNetRoles");
        }
    }
}
