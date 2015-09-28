namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOldPriceToSounds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sounds", "OldPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sounds", "OldPrice");
        }
    }
}
