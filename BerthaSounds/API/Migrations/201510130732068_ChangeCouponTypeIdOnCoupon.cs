namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCouponTypeIdOnCoupon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coupons", "CouponType_Id", "dbo.CouponTypes");
            DropIndex("dbo.Coupons", new[] { "CouponType_Id" });
            RenameColumn(table: "dbo.Coupons", name: "CouponType_Id", newName: "CouponTypeId");
            AlterColumn("dbo.Coupons", "CouponTypeId", c => c.Long(nullable: false));
            CreateIndex("dbo.Coupons", "CouponTypeId");
            AddForeignKey("dbo.Coupons", "CouponTypeId", "dbo.CouponTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coupons", "CouponTypeId", "dbo.CouponTypes");
            DropIndex("dbo.Coupons", new[] { "CouponTypeId" });
            AlterColumn("dbo.Coupons", "CouponTypeId", c => c.Long());
            RenameColumn(table: "dbo.Coupons", name: "CouponTypeId", newName: "CouponType_Id");
            CreateIndex("dbo.Coupons", "CouponType_Id");
            AddForeignKey("dbo.Coupons", "CouponType_Id", "dbo.CouponTypes", "Id");
        }
    }
}
