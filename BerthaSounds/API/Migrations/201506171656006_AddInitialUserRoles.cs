using API.Helpers;

namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialUserRoles : DbMigration
    {
        public override void Up()
        {
            MigrationHelpers.AddNewRole("Admin");
        }
        
        public override void Down()
        {
        }
    }
}
