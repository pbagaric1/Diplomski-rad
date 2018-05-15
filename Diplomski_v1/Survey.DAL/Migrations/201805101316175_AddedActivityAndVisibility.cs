namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActivityAndVisibility : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Answers", new[] { "AspNetUserId" });
            AddColumn("dbo.Polls", "Visibility", c => c.Boolean(nullable: false));
            AddColumn("dbo.Polls", "ActivityStartTime", c => c.DateTime());
            AddColumn("dbo.Polls", "ActivityDuration", c => c.Time(precision: 7));
            AlterColumn("dbo.Answers", "AspNetUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "AspNetUserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Polls", "ActivityDuration");
            DropColumn("dbo.Polls", "ActivityStartTime");
            DropColumn("dbo.Polls", "Visibility");
            CreateIndex("dbo.Answers", "AspNetUserId");
            AddForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
