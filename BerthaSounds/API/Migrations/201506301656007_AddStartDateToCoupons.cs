namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartDateToCoupons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coupons", "StartDate");
        }
    }
}
