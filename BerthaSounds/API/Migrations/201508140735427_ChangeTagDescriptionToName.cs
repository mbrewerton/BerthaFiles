namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTagDescriptionToName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Name", c => c.String());
            DropColumn("dbo.Tags", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Description", c => c.String());
            DropColumn("dbo.Tags", "Name");
        }
    }
}
