namespace API.Migrations
{
    using Helpers;
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddBrettToAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(MigrationHelpers.AddUserToRole("Brett", "Admin"));
        }
        
        public override void Down()
        {
        }
    }
}
