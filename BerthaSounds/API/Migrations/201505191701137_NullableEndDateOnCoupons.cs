namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableEndDateOnCoupons : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coupons", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Coupons", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
