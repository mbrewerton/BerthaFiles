using API.Helpers;

namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolesToDb : DbMigration
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
