namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cmm : DbMigration
    {
        public override void Up()
        {
            
            
          
           
           
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserLogin");
            AlterColumn("dbo.UserLogin", "UserId", c => c.String());
            AlterColumn("dbo.UserLogin", "LoginProvider", c => c.String());
            AddPrimaryKey("dbo.AspNetUserLogins", "ProviderKey");
            RenameTable(name: "dbo.UserLogin", newName: "AspNetUserLogins");
        }
    }
}
