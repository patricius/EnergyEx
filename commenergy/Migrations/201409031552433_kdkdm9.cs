namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kdkdm9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUserRoles", "IdentityRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserRoles", "IdentityRole_Id");
            AddForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
           
            
            AddColumn("dbo.AspNetUserRoles", "IdentityRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserRoles", "IdentityRole_Id");
            AddForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles", "Id");
        }
    }
}
