namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToCouponTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CouponTypes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CouponTypes", "Description");
        }
    }
}
