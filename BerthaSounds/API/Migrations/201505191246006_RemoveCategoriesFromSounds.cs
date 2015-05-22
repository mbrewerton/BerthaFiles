namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoriesFromSounds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Sound_Id", "dbo.Sounds");
            DropIndex("dbo.Categories", new[] { "Sound_Id" });
            DropColumn("dbo.Categories", "Sound_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Sound_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Sound_Id");
            AddForeignKey("dbo.Categories", "Sound_Id", "dbo.Sounds", "Id");
        }
    }
}
