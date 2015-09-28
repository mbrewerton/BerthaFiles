namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCouponTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CouponTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Coupons", "CouponType_Id", c => c.Long());
            CreateIndex("dbo.Coupons", "CouponType_Id");
            AddForeignKey("dbo.Coupons", "CouponType_Id", "dbo.CouponTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coupons", "CouponType_Id", "dbo.CouponTypes");
            DropIndex("dbo.Coupons", new[] { "CouponType_Id" });
            DropColumn("dbo.Coupons", "CouponType_Id");
            DropTable("dbo.CouponTypes");
        }
    }
}
