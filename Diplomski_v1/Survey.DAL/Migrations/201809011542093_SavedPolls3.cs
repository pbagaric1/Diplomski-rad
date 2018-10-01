namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavedPolls3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SavedPolls", "AspNetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SavedPolls", new[] { "AspNetUserId" });
            AddColumn("dbo.SavedPolls", "PollId", c => c.Guid(nullable: false));
            AlterColumn("dbo.SavedPolls", "AspNetUserId", c => c.String());
            AlterColumn("dbo.SavedPolls", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.SavedPolls", "PollJson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavedPolls", "PollJson", c => c.String());
            AlterColumn("dbo.SavedPolls", "DateAdded", c => c.String());
            AlterColumn("dbo.SavedPolls", "AspNetUserId", c => c.String(maxLength: 128));
            DropColumn("dbo.SavedPolls", "PollId");
            CreateIndex("dbo.SavedPolls", "AspNetUserId");
            AddForeignKey("dbo.SavedPolls", "AspNetUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
