namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dong : DbMigration
    {
        public override void Up()
        {
          
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IsApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PasswordFailuresSinceLastSuccess", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IsLockedOut", c => c.Boolean(nullable: false));
          
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "IsLockedOut", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "PasswordFailuresSinceLastSuccess", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "IsApproved", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            RenameIndex(table: "dbo.AspNetUserRoles", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.AspNetUserLogins", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            RenameColumn(table: "dbo.AspNetUserRoles", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AspNetUserLogins", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
        }
    }
}
