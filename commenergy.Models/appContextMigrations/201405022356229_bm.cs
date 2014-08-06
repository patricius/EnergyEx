namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bm : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AspNetRoles", name: "Id", newName: "RoleId");
            RenameTable(name: "dbo.AspNetRoles", newName: "IdentityRoles");
        }
    }
}
