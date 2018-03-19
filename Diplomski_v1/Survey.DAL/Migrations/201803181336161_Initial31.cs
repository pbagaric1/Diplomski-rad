namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPolls", "PollId", "dbo.Polls");
            DropIndex("dbo.UserPolls", new[] { "PollId" });
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "QuestionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "QuestionTypeId");
            AddForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Questions", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropColumn("dbo.Questions", "QuestionTypeId");
            DropTable("dbo.QuestionTypes");
            CreateIndex("dbo.UserPolls", "PollId");
            AddForeignKey("dbo.UserPolls", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
        }
    }
}
