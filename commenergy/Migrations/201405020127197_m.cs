namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.AspNetUserRoles", "IdentityRole_Id");
            DropColumn("dbo.AspNetUserRoles", "IdentityUser_Id");
            DropColumn("dbo.AspNetUserLogins", "IdentityUser_Id");
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_IdentityUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "IdentityUser_Id", newName: "User_Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
        }
    }
}
