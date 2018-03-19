namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionOptions", "QuestionChoiceId", "dbo.QuestionChoices");
            DropForeignKey("dbo.Questions", "QuestionOptionGroupId", "dbo.QuestionOptionGroups");
            DropIndex("dbo.Questions", new[] { "QuestionOptionGroupId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionChoiceId" });
            AddColumn("dbo.QuestionChoices", "QuestionId", c => c.Guid(nullable: false));
            AddColumn("dbo.QuestionOptionGroups", "QuestionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Questions", "QuestionOptionGroupId", c => c.Int());
            CreateIndex("dbo.Questions", "QuestionOptionGroupId");
            CreateIndex("dbo.QuestionChoices", "QuestionId");
            AddForeignKey("dbo.QuestionChoices", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "QuestionOptionGroupId", "dbo.QuestionOptionGroups", "Id");
            DropColumn("dbo.QuestionChoices", "QuestionOptionGroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionChoices", "QuestionOptionGroupId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Questions", "QuestionOptionGroupId", "dbo.QuestionOptionGroups");
            DropForeignKey("dbo.QuestionChoices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionChoices", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuestionOptionGroupId" });
            AlterColumn("dbo.Questions", "QuestionOptionGroupId", c => c.Int(nullable: false));
            DropColumn("dbo.QuestionOptionGroups", "QuestionId");
            DropColumn("dbo.QuestionChoices", "QuestionId");
            CreateIndex("dbo.QuestionOptions", "QuestionChoiceId");
            CreateIndex("dbo.QuestionOptions", "QuestionId");
            CreateIndex("dbo.Questions", "QuestionOptionGroupId");
            AddForeignKey("dbo.Questions", "QuestionOptionGroupId", "dbo.QuestionOptionGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionOptions", "QuestionChoiceId", "dbo.QuestionChoices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
