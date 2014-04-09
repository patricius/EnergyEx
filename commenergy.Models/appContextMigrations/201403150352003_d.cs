namespace commenergy.Models.appContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
   
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Author = c.String(nullable: false, maxLength: 75),
                        Body = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IpAddress = c.String(nullable: false),
                        URL = c.String(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        UserId = c.String(maxLength: 128),
                        Abstract = c.String(),
                        Key = c.String(maxLength: 75),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Title = c.String(nullable: false, maxLength: 75),
                        MetaDescription = c.String(nullable: false, maxLength: 250),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Articles", "UserId");
            CreateIndex("dbo.Comments", "ArticleId");
            AddForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
