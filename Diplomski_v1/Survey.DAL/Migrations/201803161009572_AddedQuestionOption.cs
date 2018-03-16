namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuestionOption : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RadiogroupQuestionId = c.Guid(),
                        CheckboxQuestionId = c.Guid(),
                        Choice = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckboxQuestions", t => t.CheckboxQuestionId)
                .Index(t => t.CheckboxQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionChoices", "CheckboxQuestionId", "dbo.CheckboxQuestions");
            DropIndex("dbo.QuestionChoices", new[] { "CheckboxQuestionId" });
            DropTable("dbo.QuestionChoices");
        }
    }
}
