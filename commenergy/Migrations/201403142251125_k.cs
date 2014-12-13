namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Comments", "Article_UserId", "dbo.Articles");
            //DropForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers");
            //DropIndex("dbo.Comments", new[] { "Article_UserId" });
            //DropIndex("dbo.Articles", new[] { "UserId" });
          
        
            //AlterColumn("dbo.Articles", "UserId", c => c.String(maxLength: 128));
            //AlterColumn("dbo.Articles", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Comments", "ArticleId", c => c.Int(nullable: false));
            //DropPrimaryKey("dbo.Articles");
            //AddPrimaryKey("dbo.Articles", "Id");
          
            //CreateIndex("dbo.Articles", "UserId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropPrimaryKey("dbo.Articles");
            AddPrimaryKey("dbo.Articles", "UserId");
            AlterColumn("dbo.Comments", "ArticleId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Articles", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "UserId", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Comments", name: "ArticleId", newName: "Article_UserId");
            AddColumn("dbo.Comments", "ArticleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "UserId");
            CreateIndex("dbo.Comments", "Article_UserId");
            AddForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "Article_UserId", "dbo.Articles", "UserId");
        }
    }
}
