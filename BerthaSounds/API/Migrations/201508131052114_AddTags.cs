namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTags : DbMigration
    {
        public override void Up()
        {
	        CreateTable("dbo.Tags",
		        c => new
		        {
			        Id = c.Int(nullable: false, identity: true),
			        Description = c.String()
		        })
		        .PrimaryKey(s => s.Id);
        }
        
        public override void Down()
        {
			DropTable("dbo.Tags");
        }
    }
}
