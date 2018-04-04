namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAnswerDto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "QuestionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Answers", "AspNetUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Answers", "QuestionOptionId");
            CreateIndex("dbo.Answers", "QuestionId");
            CreateIndex("dbo.Answers", "AspNetUserId");
            CreateIndex("dbo.QuestionOptions", "QuestionId");
            CreateIndex("dbo.QuestionOptions", "QuestionChoiceId");
            AddForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.QuestionOptions", "QuestionChoiceId", "dbo.QuestionChoices", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuestionOptions", "QuestionChoiceId", "dbo.QuestionChoices");
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionOptions", new[] { "QuestionChoiceId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "AspNetUserId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "QuestionOptionId" });
            AlterColumn("dbo.Answers", "AspNetUserId", c => c.String());
            DropColumn("dbo.Answers", "QuestionId");
        }
    }
}
