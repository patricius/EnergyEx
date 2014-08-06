namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityfixattempt3 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.AspNetUsers", "UserId", c => c.String());
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "UserId1", newName: "UserId");
            RenameColumn(table: "dbo.AspNetUsers", name: "UserId", newName: "Id");
            AddForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers", "UserId");
            AddForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers", "UserId");
            AddForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.AspNetUsers", "UserId");
            AddForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers", "UserId");
            AddForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers", "UserId");
        }
    }
}
