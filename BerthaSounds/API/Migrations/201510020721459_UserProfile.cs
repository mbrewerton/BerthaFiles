namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserProfileId", c => c.Long(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserProfileId");
            AddForeignKey("dbo.AspNetUsers", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.AspNetUsers", new[] { "UserProfileId" });
            DropColumn("dbo.AspNetUsers", "UserProfileId");
            DropTable("dbo.UserProfiles");
        }
    }
}
