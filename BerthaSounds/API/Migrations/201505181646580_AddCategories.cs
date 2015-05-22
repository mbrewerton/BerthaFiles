namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Sound_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sounds", t => t.Sound_Id)
                .Index(t => t.Sound_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Sound_Id", "dbo.Sounds");
            DropIndex("dbo.Categories", new[] { "Sound_Id" });
            DropTable("dbo.Categories");
        }
    }
}
