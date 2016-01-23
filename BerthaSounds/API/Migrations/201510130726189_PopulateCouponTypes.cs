using API.Enums;
using API.Helpers;

namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCouponTypes : DbMigration
    {
		public override void Up()
		{
			string table = "CouponTypes";
			Sql(MigrationHelpers.SetIdentityInsert(table, true));
			Sql(string.Format(@"INSERT INTO dbo.[CouponTypes](Id, Name, Description) VALUES (1, '{0}', '{1}')", CouponTypeEnum.BasketTotalAmount, "Basket Total Amount"));
			Sql(string.Format(@"INSERT INTO dbo.[CouponTypes](Id, Name, Description) VALUES (2, '{0}', '{1}')", CouponTypeEnum.BasketTotalPercent, "Basket Total Percent"));
			Sql(MigrationHelpers.SetIdentityInsert(table, false));
		}

		public override void Down()
		{
			Sql(string.Format("DELETE FROM dbo.[CouponTypes] WHERE Name = '{0}'", CouponTypeEnum.BasketTotalAmount));
			Sql(string.Format("DELETE FROM dbo.[CouponTypes] WHERE Name = '{0}'", CouponTypeEnum.BasketTotalPercent));
		}
    }
}
