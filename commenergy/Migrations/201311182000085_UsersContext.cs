namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "User_UserId" });
            RenameColumn(table: "dbo.UserRoles", name: "User_UserId", newName: "User_Id");
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserRoles", "User_Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.UserRoles", "User_Id");
            AddForeignKey("dbo.UserRoles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "UserId");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", "UserId");
            AlterColumn("dbo.UserRoles", "User_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Users", "Id");
            RenameColumn(table: "dbo.UserRoles", name: "User_Id", newName: "User_UserId");
            CreateIndex("dbo.UserRoles", "User_UserId");
            AddForeignKey("dbo.UserRoles", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
