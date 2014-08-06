namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class csed : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 254));
            RenameColumn(table: "dbo.AspNetUsers", name: "Email", newName: "EmailAddress");
        }
    }
}
