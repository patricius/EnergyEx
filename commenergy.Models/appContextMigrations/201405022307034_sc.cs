namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sc : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.IdentityRoles", name: "RoleId", newName: "Id");
            RenameTable(name: "dbo.IdentityRoles", newName: "AspNetRoles");
        }
    }
}
