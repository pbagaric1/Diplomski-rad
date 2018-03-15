namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseRedesign1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "InputTypeId", "dbo.InputTypes");
            DropForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups");
            DropForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions");
            DropForeignKey("dbo.OptionChoices", "OptionGroupId", "dbo.OptionGroups");
            DropForeignKey("dbo.QuestionOptions", "OptionChoiceId", "dbo.OptionChoices");
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.UserPolls", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPolls", "PollId", "dbo.Polls");
            DropForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionOptionId" });
            DropIndex("dbo.Answers", new[] { "AspNetUserId" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "InputTypeId" });
            DropIndex("dbo.Questions", new[] { "OptionGroupId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.QuestionOptions", new[] { "OptionChoiceId" });
            DropIndex("dbo.OptionChoices", new[] { "OptionGroupId" });
            DropIndex("dbo.UserPolls", new[] { "AspNetUserId" });
            DropIndex("dbo.UserPolls", new[] { "PollId" });
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                        Name = c.String(),
                        minimumRateDescription = c.String(),
                        maximumRateDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            AddColumn("dbo.QuestionOptions", "QuestionChoiceId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Answers", "AspNetUserId", c => c.String());
            AlterColumn("dbo.UserPolls", "AspNetUserId", c => c.String());
            DropColumn("dbo.Answers", "Question_Id");
            DropColumn("dbo.QuestionOptions", "OptionChoiceId");
            DropTable("dbo.OptionGroups");
            DropTable("dbo.OptionChoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OptionChoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OptionGroupId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OptionGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MinValue = c.String(),
                        MaxValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QuestionOptions", "OptionChoiceId", c => c.Guid(nullable: false));
            AddColumn("dbo.Answers", "Question_Id", c => c.Guid());
            DropForeignKey("dbo.QuestionChoices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionChoices", new[] { "QuestionId" });
            AlterColumn("dbo.UserPolls", "AspNetUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Answers", "AspNetUserId", c => c.String(maxLength: 128));
            DropColumn("dbo.QuestionOptions", "QuestionChoiceId");
            DropTable("dbo.QuestionChoices");
            CreateIndex("dbo.UserPolls", "PollId");
            CreateIndex("dbo.UserPolls", "AspNetUserId");
            CreateIndex("dbo.OptionChoices", "OptionGroupId");
            CreateIndex("dbo.QuestionOptions", "OptionChoiceId");
            CreateIndex("dbo.QuestionOptions", "QuestionId");
            CreateIndex("dbo.Questions", "OptionGroupId");
            CreateIndex("dbo.Questions", "InputTypeId");
            CreateIndex("dbo.Answers", "Question_Id");
            CreateIndex("dbo.Answers", "AspNetUserId");
            CreateIndex("dbo.Answers", "QuestionOptionId");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserPolls", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserPolls", "AspNetUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionOptions", "OptionChoiceId", "dbo.OptionChoices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OptionChoices", "OptionGroupId", "dbo.OptionGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups", "Id");
            AddForeignKey("dbo.Questions", "InputTypeId", "dbo.InputTypes", "Id", cascadeDelete: true);
        }
    }
}
