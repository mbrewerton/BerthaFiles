namespace API.Migrations
{
    using Helpers;
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(MigrationHelpers.AddNewRole("Admin"));
        }
        
        public override void Down()
        {
        }
    }
}
