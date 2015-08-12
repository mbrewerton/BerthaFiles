namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAzureLocationToSound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sounds", "AzureLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sounds", "AzureLocation");
        }
    }
}
