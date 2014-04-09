namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fl : DbMigration
    {
        public override void Up()
        {
   
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Article_UserId", "dbo.Articles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Article_UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropPrimaryKey("dbo.Articles");
            AddPrimaryKey("dbo.Articles", "Id");
            AlterColumn("dbo.Articles", "UserId", c => c.String());
            AlterColumn("dbo.Articles", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Comments", "Article_UserId");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            CreateIndex("dbo.Comments", "ArticleId");
            AddForeignKey("dbo.Comments", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
