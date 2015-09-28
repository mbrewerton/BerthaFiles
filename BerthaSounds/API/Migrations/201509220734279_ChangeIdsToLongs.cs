namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdsToLongs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SoundCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.SoundCategories", "Sound_Id", "dbo.Sounds");
            DropForeignKey("dbo.SoundTags", "Sound_Id", "dbo.Sounds");
            DropForeignKey("dbo.SoundTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Sounds", "SoundPack_Id", "dbo.SoundPacks");
            DropIndex("dbo.Sounds", new[] { "SoundPack_Id" });
            DropIndex("dbo.SoundCategories", new[] { "Sound_Id" });
            DropIndex("dbo.SoundCategories", new[] { "Category_Id" });
            DropIndex("dbo.SoundTags", new[] { "Sound_Id" });
            DropIndex("dbo.SoundTags", new[] { "Tag_Id" });
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Coupons");
            DropPrimaryKey("dbo.Sounds");
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.SoundPacks");
            DropPrimaryKey("dbo.SoundCategories");
            DropPrimaryKey("dbo.SoundTags");
            AlterColumn("dbo.Categories", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Coupons", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Sounds", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Sounds", "SoundPack_Id", c => c.Long());
            AlterColumn("dbo.Tags", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.SoundPacks", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.SoundCategories", "Sound_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.SoundCategories", "Category_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.SoundTags", "Sound_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.SoundTags", "Tag_Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Coupons", "Id");
            AddPrimaryKey("dbo.Sounds", "Id");
            AddPrimaryKey("dbo.Tags", "Id");
            AddPrimaryKey("dbo.SoundPacks", "Id");
            AddPrimaryKey("dbo.SoundCategories", new[] { "Sound_Id", "Category_Id" });
            AddPrimaryKey("dbo.SoundTags", new[] { "Sound_Id", "Tag_Id" });
            CreateIndex("dbo.Sounds", "SoundPack_Id");
            CreateIndex("dbo.SoundCategories", "Sound_Id");
            CreateIndex("dbo.SoundCategories", "Category_Id");
            CreateIndex("dbo.SoundTags", "Sound_Id");
            CreateIndex("dbo.SoundTags", "Tag_Id");
            AddForeignKey("dbo.SoundCategories", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SoundCategories", "Sound_Id", "dbo.Sounds", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SoundTags", "Sound_Id", "dbo.Sounds", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SoundTags", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sounds", "SoundPack_Id", "dbo.SoundPacks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sounds", "SoundPack_Id", "dbo.SoundPacks");
            DropForeignKey("dbo.SoundTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.SoundTags", "Sound_Id", "dbo.Sounds");
            DropForeignKey("dbo.SoundCategories", "Sound_Id", "dbo.Sounds");
            DropForeignKey("dbo.SoundCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.SoundTags", new[] { "Tag_Id" });
            DropIndex("dbo.SoundTags", new[] { "Sound_Id" });
            DropIndex("dbo.SoundCategories", new[] { "Category_Id" });
            DropIndex("dbo.SoundCategories", new[] { "Sound_Id" });
            DropIndex("dbo.Sounds", new[] { "SoundPack_Id" });
            DropPrimaryKey("dbo.SoundTags");
            DropPrimaryKey("dbo.SoundCategories");
            DropPrimaryKey("dbo.SoundPacks");
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.Sounds");
            DropPrimaryKey("dbo.Coupons");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.SoundTags", "Tag_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SoundTags", "Sound_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SoundCategories", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SoundCategories", "Sound_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SoundPacks", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Tags", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sounds", "SoundPack_Id", c => c.Int());
            AlterColumn("dbo.Sounds", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Coupons", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SoundTags", new[] { "Sound_Id", "Tag_Id" });
            AddPrimaryKey("dbo.SoundCategories", new[] { "Sound_Id", "Category_Id" });
            AddPrimaryKey("dbo.SoundPacks", "Id");
            AddPrimaryKey("dbo.Tags", "Id");
            AddPrimaryKey("dbo.Sounds", "Id");
            AddPrimaryKey("dbo.Coupons", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.SoundTags", "Tag_Id");
            CreateIndex("dbo.SoundTags", "Sound_Id");
            CreateIndex("dbo.SoundCategories", "Category_Id");
            CreateIndex("dbo.SoundCategories", "Sound_Id");
            CreateIndex("dbo.Sounds", "SoundPack_Id");
            AddForeignKey("dbo.Sounds", "SoundPack_Id", "dbo.SoundPacks", "Id");
            AddForeignKey("dbo.SoundTags", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SoundTags", "Sound_Id", "dbo.Sounds", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SoundCategories", "Sound_Id", "dbo.Sounds", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SoundCategories", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
