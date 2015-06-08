namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileNameToSound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sounds", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sounds", "FileName");
        }
    }
}
