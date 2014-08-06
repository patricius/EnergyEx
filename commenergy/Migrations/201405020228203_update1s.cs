namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class update1s : DbMigration
    {

        public override void Up()
        {



            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: true, maxLength: 128));


          

        }

        public override void Down()
        {

            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));

            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());

            DropColumn("dbo.AspNetUsers", "IsConfirmed");

            DropColumn("dbo.AspNetUsers", "Email");

            RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "User_Id");

        }
    }
}
      
