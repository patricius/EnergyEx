namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            AlterColumn("dbo.Articles", "UserId", c => c.String());

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_RoleId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        Comment = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        LastPasswordFailureDate = c.DateTime(),
                        LastActivityDate = c.DateTime(),
                        LastLockoutDate = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        ConfirmationToken = c.String(),
                        CreateDate = c.DateTime(),
                        IsLockedOut = c.Boolean(nullable: false),
                        LastPasswordChangedDate = c.DateTime(),
                        PasswordVerificationToken = c.String(),
                        PasswordVerificationTokenExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AlterColumn("dbo.Articles", "UserId", c => c.Int());
            CreateIndex("dbo.UserRoles", "Role_RoleId");
            CreateIndex("dbo.UserRoles", "User_Id");
            CreateIndex("dbo.Articles", "UserId");
            AddForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "UserId", "dbo.Users", "Id");
        }
    }
}
