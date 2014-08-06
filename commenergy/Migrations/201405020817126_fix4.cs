namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix4 : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "IsApproved", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "PasswordFailuresSinceLastSuccess", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "IsLockedOut", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "IsLockedOut", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PasswordFailuresSinceLastSuccess", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IsApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Discriminator");
            RenameIndex(table: "dbo.AspNetUserRoles", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.AspNetUserLogins", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.AspNetUserRoles", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.AspNetUserLogins", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
        }
    }
}
