namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavedPolls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedPolls",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.String(maxLength: 128),
                        PollJson = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavedPolls", "AspNetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SavedPolls", new[] { "AspNetUserId" });
            DropTable("dbo.SavedPolls");
        }
    }
}
