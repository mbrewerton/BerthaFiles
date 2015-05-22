namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoundPacks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoundPacks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);
            AddColumn("dbo.Sounds", "SoundPack_Id", c => c.Int());
            CreateIndex("dbo.Sounds", "SoundPack_Id");
            AddForeignKey("dbo.Sounds", "SoundPack_Id", "dbo.SoundPacks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sounds", "SoundPack_Id", "dbo.SoundPacks");
            DropIndex("dbo.Sounds", new[] { "SoundPack_Id" });
            DropColumn("dbo.Sounds", "SoundPack_Id");
            DropTable("dbo.SoundPacks");
        }
    }
}
