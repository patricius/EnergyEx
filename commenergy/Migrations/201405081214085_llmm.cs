namespace commenergy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class llmm : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Ratings", "EnergyDrinkId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "EnergyDrinkId");
        }
    }
}
