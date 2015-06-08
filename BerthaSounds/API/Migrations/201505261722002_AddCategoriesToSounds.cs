namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesToSounds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Sound_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Sound_Id");
            AddForeignKey("dbo.Categories", "Sound_Id", "dbo.Sounds", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Sound_Id", "dbo.Sounds");
            DropIndex("dbo.Categories", new[] { "Sound_Id" });
            DropColumn("dbo.Categories", "Sound_Id");
        }
    }
}
