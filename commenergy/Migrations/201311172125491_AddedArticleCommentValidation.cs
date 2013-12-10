namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArticleCommentValidation : DbMigration
    {
        public override void Up()
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
                        ArticleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
