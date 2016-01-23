namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountToCoupon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coupons", "Amount");
        }
    }
}
