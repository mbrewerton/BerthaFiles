namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndDateToCoupons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Coupons", "Code", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Coupons", "Code", c => c.String(nullable: false));
            DropColumn("dbo.Coupons", "EndDate");
        }
    }
}
