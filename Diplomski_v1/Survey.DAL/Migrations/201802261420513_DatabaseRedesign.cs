namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseRedesign : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Polls", "PollTypeId", "dbo.PollTypes");
            DropForeignKey("dbo.PollResults", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.PollResults", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PollResults", "PollId", "dbo.Polls");
            DropForeignKey("dbo.PollResults", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Polls", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Polls", new[] { "UserId" });
            DropIndex("dbo.Polls", new[] { "PollTypeId" });
            DropIndex("dbo.PollResults", new[] { "AspNetUserId" });
            DropIndex("dbo.PollResults", new[] { "PollId" });
            DropIndex("dbo.PollResults", new[] { "QuestionId" });
            DropIndex("dbo.PollResults", new[] { "AnswerId" });
            RenameColumn(table: "dbo.Answers", name: "QuestionId", newName: "Question_Id");
            RenameColumn(table: "dbo.Polls", name: "UserId", newName: "AspNetUserId");
            CreateTable(
                "dbo.InputTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
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
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                        QuestionChoiceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionChoices", t => t.QuestionChoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.QuestionChoiceId);
            
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OptionGroupId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OptionGroups", t => t.OptionGroupId, cascadeDelete: false)
                .Index(t => t.OptionGroupId);
            
            CreateTable(
                "dbo.UserPolls",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.String(maxLength: 128),
                        PollId = c.Guid(nullable: false),
                        CompletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.AspNetUserId)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Answers", "QuestionOptionId", c => c.Guid(nullable: false));
            AddColumn("dbo.Answers", "AspNetUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Questions", "InputTypeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Questions", "OptionGroupId", c => c.Guid(nullable: false));
            AddColumn("dbo.Questions", "Title", c => c.String());
            AddColumn("dbo.Questions", "AnswerRequired", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questions", "QuestionOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Polls", "OrganizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Polls", "Instructions", c => c.String());
            AddColumn("dbo.Polls", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Answers", "Question_Id", c => c.Guid());
            AlterColumn("dbo.Polls", "AspNetUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Answers", "QuestionOptionId");
            CreateIndex("dbo.Answers", "AspNetUserId");
            CreateIndex("dbo.Answers", "Question_Id");
            CreateIndex("dbo.Polls", "AspNetUserId");
            CreateIndex("dbo.Questions", "InputTypeId");
            CreateIndex("dbo.Questions", "OptionGroupId");
            AddForeignKey("dbo.Questions", "InputTypeId", "dbo.InputTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Polls", "AspNetUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Questions", "Name");
            DropColumn("dbo.Polls", "PollTypeId");
            DropColumn("dbo.Polls", "Location");
            DropTable("dbo.PollTypes");
            DropTable("dbo.PollResults");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PollResults",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.String(maxLength: 128),
                        PollId = c.Guid(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                        AnswerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PollTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Polls", "Location", c => c.String());
            AddColumn("dbo.Polls", "PollTypeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Questions", "Name", c => c.String());
            DropForeignKey("dbo.Polls", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Answers", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPolls", "PollId", "dbo.Polls");
            DropForeignKey("dbo.UserPolls", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionOptions", "QuestionChoiceId", "dbo.QuestionChoices");
            DropForeignKey("dbo.QuestionChoices", "OptionGroupId", "dbo.OptionGroups");
            DropForeignKey("dbo.Answers", "QuestionOptionId", "dbo.QuestionOptions");
            DropForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups");
            DropForeignKey("dbo.Questions", "InputTypeId", "dbo.InputTypes");
            DropIndex("dbo.UserPolls", new[] { "PollId" });
            DropIndex("dbo.UserPolls", new[] { "AspNetUserId" });
            DropIndex("dbo.QuestionChoices", new[] { "OptionGroupId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionChoiceId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "OptionGroupId" });
            DropIndex("dbo.Questions", new[] { "InputTypeId" });
            DropIndex("dbo.Polls", new[] { "AspNetUserId" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Answers", new[] { "AspNetUserId" });
            DropIndex("dbo.Answers", new[] { "QuestionOptionId" });
            AlterColumn("dbo.Polls", "AspNetUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Answers", "Question_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Polls", "CreatedOn");
            DropColumn("dbo.Polls", "Instructions");
            DropColumn("dbo.Polls", "OrganizationId");
            DropColumn("dbo.Questions", "QuestionOrder");
            DropColumn("dbo.Questions", "AnswerRequired");
            DropColumn("dbo.Questions", "Title");
            DropColumn("dbo.Questions", "OptionGroupId");
            DropColumn("dbo.Questions", "InputTypeId");
            DropColumn("dbo.Answers", "AspNetUserId");
            DropColumn("dbo.Answers", "QuestionOptionId");
            DropTable("dbo.Organizations");
            DropTable("dbo.UserPolls");
            DropTable("dbo.QuestionChoices");
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.OptionGroups");
            DropTable("dbo.InputTypes");
            RenameColumn(table: "dbo.Polls", name: "AspNetUserId", newName: "UserId");
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "QuestionId");
            CreateIndex("dbo.PollResults", "AnswerId");
            CreateIndex("dbo.PollResults", "QuestionId");
            CreateIndex("dbo.PollResults", "PollId");
            CreateIndex("dbo.PollResults", "AspNetUserId");
            CreateIndex("dbo.Polls", "PollTypeId");
            CreateIndex("dbo.Polls", "UserId");
            CreateIndex("dbo.Answers", "QuestionId");
            AddForeignKey("dbo.Polls", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PollResults", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PollResults", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PollResults", "AspNetUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PollResults", "AnswerId", "dbo.Answers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Polls", "PollTypeId", "dbo.PollTypes", "Id", cascadeDelete: true);
        }
    }
}
