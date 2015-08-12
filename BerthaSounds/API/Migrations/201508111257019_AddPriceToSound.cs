namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToSound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sounds", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sounds", "Price");
        }
    }
}
