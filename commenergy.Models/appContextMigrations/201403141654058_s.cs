namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            
  
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AspNetUserRoles");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            DropPrimaryKey("dbo.AspNetUserLogins");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "UserId", "LoginProvider", "ProviderKey" });
            AlterColumn("dbo.AspNetUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
