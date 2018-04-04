namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAnswerDto1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions");
            DropIndex("dbo.Answers", new[] { "QuestionOptionId" });
            AlterColumn("dbo.Answers", "QuestionOptionId", c => c.Guid());
            CreateIndex("dbo.Answers", "QuestionOptionId");
            AddForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions");
            DropIndex("dbo.Answers", new[] { "QuestionOptionId" });
            AlterColumn("dbo.Answers", "QuestionOptionId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Answers", "QuestionOptionId");
            AddForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions", "Id", cascadeDelete: true);
        }
    }
}
