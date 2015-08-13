namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagsAndCategoriesToSounds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Sound_Id", "dbo.Sounds");
            DropIndex("dbo.Tags", new[] { "Sound_Id" });
            CreateTable(
                "dbo.SoundCategories",
                c => new
                    {
                        Sound_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sound_Id, t.Category_Id })
                .ForeignKey("dbo.Sounds", t => t.Sound_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Sound_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.SoundTags",
                c => new
                    {
                        Sound_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sound_Id, t.Tag_Id })
                .ForeignKey("dbo.Sounds", t => t.Sound_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Sound_Id)
                .Index(t => t.Tag_Id);
            
			//DropColumn("dbo.Tags", "Sound_Id");
        }
        
        public override void Down()
        {
			//AddColumn("dbo.Tags", "Sound_Id", c => c.Int());
            DropForeignKey("dbo.SoundTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.SoundTags", "Sound_Id", "dbo.Sounds");
            DropForeignKey("dbo.SoundCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.SoundCategories", "Sound_Id", "dbo.Sounds");
            DropIndex("dbo.SoundTags", new[] { "Tag_Id" });
            DropIndex("dbo.SoundTags", new[] { "Sound_Id" });
            DropIndex("dbo.SoundCategories", new[] { "Category_Id" });
            DropIndex("dbo.SoundCategories", new[] { "Sound_Id" });
            DropTable("dbo.SoundTags");
            DropTable("dbo.SoundCategories");
            CreateIndex("dbo.Tags", "Sound_Id");
            AddForeignKey("dbo.Tags", "Sound_Id", "dbo.Sounds", "Id");
        }
    }
}
