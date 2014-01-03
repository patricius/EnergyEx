namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridnullable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "UserId");
            RenameColumn(table: "dbo.Articles", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Articles", "UserId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "UserId", c => c.String());
            RenameColumn(table: "dbo.Articles", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Articles", "UserId", c => c.String());
        }
    }
}
